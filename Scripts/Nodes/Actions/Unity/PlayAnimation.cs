using UnityEngine;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Animation/"+nameof(PlayAnimation), "Play", "Animation", "Animator")]
    public class PlayAnimation : FlowNode {
        [Input] public Animator Target;
        [Input] public string StateName;

        public override void ExecuteNode() {
            var animator = GetInputValue(nameof(Target), Target);
            var stateName = GetInputValue(nameof(StateName), StateName);
            animator.Play(stateName);
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
