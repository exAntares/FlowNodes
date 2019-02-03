using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Animation/Tween/" + nameof(DoTweenAlpha), "Tween", "Alpha")]
    public class DoTweenAlpha : BaseDoTween {
        [Input] public Graphic Target;
        [Input] public float TargetValue;
        private Material objectMaterial;

        protected override void Init() {
            base.Init();
            if (Target != null) {
                var target = GetInputValue(nameof(Target), Target);
                objectMaterial = new Material(target.material);
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
                SetupTween(tween);
            }
        }
    }
}
