using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using XNode;

namespace HalfBlind.FlowNodes {
    [CreateNodeMenu("Actions/Tween/" + nameof(DoTweenAlpha), "Tween", "Alpha")]
    public class DoTweenAlpha : FlowNode {
        [Input] public Graphic Target;
        [Input] public float TargetValue;
        [Input] public int Duration;
        public bool IsLoop;
        public LoopType Loop;
        public Ease Easing = Ease.Linear;

        private Tweener tween;
        private float targetYoyo;
        private Material objectMaterial;

        protected override void Init() {
            base.Init();
            if (Target != null) {
                var target = GetInputValue(nameof(Target), Target);
                objectMaterial = new Material(target.material);
                targetYoyo = objectMaterial.color.a;
                target.material = objectMaterial;
            }
        }

        public override void ExecuteNode() {
            StartTween(GetInputValue(nameof(TargetValue), TargetValue));
        }

        public void StartTween(float targetValue) {
            if (tween == null) {
                var target = GetInputValue(nameof(Target), Target);
                var duration = GetInputValue(nameof(Duration), Duration);

                tween = objectMaterial.DOFade(targetValue, duration);
                tween.SetEase(Easing);
                tween.onUpdate += OnUpdateTween;
                tween.onComplete += OnTweenComplete;
            }
        }

        private void OnTweenComplete() {
            tween = null;
            if (IsLoop) {
                var target = GetInputValue(nameof(Target), Target);
                var targetVal = GetInputValue(nameof(TargetValue), TargetValue);
                switch (Loop) {
                    case LoopType.Incremental:
                        StartTween(objectMaterial.color.a + targetVal);
                        break;
                    case LoopType.Yoyo:
                        var currentAlpha = objectMaterial.color.a;
                        StartTween(targetYoyo);
                        targetYoyo = currentAlpha;
                        break;
                }
            }
        }

        private void OnUpdateTween() {
            TriggerFlow();
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            return null; // Replace this
        }
    }
}
