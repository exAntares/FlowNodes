using UnityEngine;
using UnityEngine.UI;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("UI/"+ nameof(SetText), "Set", "Text")]
    public class SetText : FlowNode {
        [Input] public Text Target;
        [Input] public string Text;

        public override void ExecuteNode() {
            var target = GetInputValue(nameof(Target), Target);
            var text = GetInputValue<object>(nameof(Text), Text);
            target.text = $"{text}";
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            return null; // Replace this
        }
    }
}
