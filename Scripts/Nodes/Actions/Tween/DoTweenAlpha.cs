using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Animation/Tween/" + nameof(DoTweenAlpha), "Tween", "Alpha")]
    public class DoTweenAlpha : BaseDoTween {
        [Input] public Graphic Target;
        [Input] public float TargetValue;
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

        public override void TriggerFlow() {
            //base.TriggerFlow();
        }

        public override void ExecuteNode() {
            StartTween(GetInputValue(nameof(TargetValue), TargetValue));
        }

        public void StartTween(float targetValue) {
            if (tween == null) {
                var target = GetInputValue(nameof(Target), Target);
                var duration = GetInputValue(nameof(Duration), Duration);
                tween = objectMaterial.DOFade(targetValue, duration);
                SetupTween(tween);
            }
        }

        protected override void OnStepComplete() {
            var target = GetInputValue(nameof(Target), Target);
            var targetVal = GetInputValue(nameof(TargetValue), TargetValue);
            switch (Loop) {
                case LoopType.Incremental:
                    tween.ChangeEndValue(objectMaterial.color.a + targetVal);
                    break;
                case LoopType.Yoyo:
                    var currentAlpha = objectMaterial.color.a;
                    //tween.ChangeEndValue(targetYoyo);
                    targetYoyo = currentAlpha;
                    break;
            }
        }

        protected override void OnTweenComplete() {
            base.TriggerFlow();
            tween = null;
        }
    }
}
