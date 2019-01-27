using UnityEngine;
using XNode;

namespace Actions.UnityNative {
    [CreateNodeMenu("GameObject/SetActiveMultiple", "visible", "multiple")]
    public class SetActiveMultiple : FlowNode {
        public enum ActiveOptions {
            Enable,
            Disable,
            Toggle,
        }

        [Input] public GameObject[] Target;
        public ActiveOptions Options;

        // Use this for initialization
        protected override void Init() {
            base.Init();
        }

        public override void ExecuteNode() {
            var targets = GetInputValue<GameObject[]>(nameof(Target), Target);
            for (int i = 0; i < targets.Length; i++) {
                var target = targets[i];
                var isActive = Options == ActiveOptions.Enable ? true : Options == ActiveOptions.Disable ? false : !target.activeSelf;
                target.SetActive(isActive);
            }
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            return null; // Replace this
        }
    }
}
