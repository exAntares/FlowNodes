using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using XNode;

namespace HalfBlind.FlowNodes {
    [CreateNodeMenu("Actions/Tween/" + nameof(DoTweenScaleTo), "Tween", "Scale")]
    public class DoTweenScaleTo : FlowNode {
        [Input] public GameObject Target;
        [Input] public Vector3 TargetValue;
        [Input] public float Duration;
        [Input] public float DelaySeconds;
        public bool IsLoop;
        public LoopType Loop;
        public Ease Easing;

        private Tweener tween;

        protected override void Init() {
            base.Init();
        }

        public override void ExecuteNode() {
            StartTween(GetInputValue(nameof(TargetValue), TargetValue));
        }

        public async Task StartTween(Vector3 targetValue) {
            if (tween == null) {
                var target = GetInputValue(nameof(Target), Target);
                var duration = GetInputValue(nameof(Duration), Duration);
                await Task.Delay((int)(DelaySeconds * 1000));
                tween = target.transform.DOScale(targetValue, duration);
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
                        StartTween(target.transform.localScale + targetVal);
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
