using UnityEngine;
using XNode;

namespace Actions.UnityNative {
    public class LogNode : FlowNode {
        [Input] public string Text;

        public override void ExecuteNode() {
            Debug.Log(GetInputValue<string>(nameof(Text), Text));
            TriggerFlow();
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
