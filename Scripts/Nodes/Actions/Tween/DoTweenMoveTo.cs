using DG.Tweening;
using UnityEngine;
using XNode;

namespace HalfBlind.FlowNodes {
    [CreateNodeMenu("Actions/Tween/" + nameof(DoTweenMoveTo), "Tween", "MoveTo")]
    public class DoTweenMoveTo : FlowNode {
        [Input] public GameObject Target;
        [Input] public Vector3 TargetValue;
        [Input] public int Duration;
        public bool IsLoop;
        public LoopType Loop;
        public Ease Easing;

        private Tweener tween;

        public override void ExecuteNode() {
            StartTween(GetInputValue(nameof(TargetValue), TargetValue));
        }

        public void StartTween(Vector3 targetValue) {
            if (tween == null) {
                var target = GetInputValue(nameof(Target), Target);
                var duration = GetInputValue(nameof(Duration), Duration);

                tween = target.transform.DOMove(targetValue, duration);
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
                        StartTween(target.transform.position + targetVal);
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
