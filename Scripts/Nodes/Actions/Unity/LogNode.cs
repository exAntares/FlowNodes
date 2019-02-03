using UnityEngine;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Utils/"+nameof(LogNode), "Log", "Print")]
    public class LogNode : FlowNode {
        [Input] public string Text;

        public override void ExecuteNode() {
            Debug.Log(GetInputValue<string>(nameof(Text), Text));
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
