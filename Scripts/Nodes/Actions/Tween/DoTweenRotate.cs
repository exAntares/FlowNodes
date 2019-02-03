using DG.Tweening;
using UnityEngine;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Animation/Tween/" + nameof(DoTweenRotate), "Tween", "Rotate")]
    public class DoTweenRotate : BaseDoTween {
        [Input] public GameObject Target;
        [Input] public Vector3 TargetValue;

        public override void ExecuteNode() {
            StartTween(GetInputValue(nameof(TargetValue), TargetValue));
        }

        public override void TriggerFlow() {
            //base.TriggerFlow();
        }

        public void StartTween(Vector3 targetValue) {
            if (tween == null) {
                var target = GetInputValue(nameof(Target), Target);
                var duration = GetInputValue(nameof(Duration), Duration);
                tween = target.transform.DORotate(targetValue, duration);
                SetupTween(tween);
            }
        }

        protected override void OnStepComplete() {
            var target = GetInputValue(nameof(Target), Target);
            var targetVal = GetInputValue(nameof(TargetValue), TargetValue);
            switch (Loop) {
                case LoopType.Incremental:
                    tween.ChangeEndValue(target.transform.rotation.eulerAngles + targetVal);
                    break;
                case LoopType.Yoyo:
                    break;
            }
        }

        protected override void OnTweenComplete() {
            base.TriggerFlow();
            tween = null;
        }
    }
}
