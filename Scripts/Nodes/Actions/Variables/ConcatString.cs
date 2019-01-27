using UnityEngine;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Variables/Actions/" + nameof(ConcatString), "String", "add")]
    public class ConcatString : FlowNode {
        [Input] public string First;
        [Input] public string Second;
        [Output] public string Result;

        public override void ExecuteNode() {
            var first = GetInputValue(nameof(First), First);
            var second = GetInputValue(nameof(Second), Second);
            Result = $"{first}{second}";
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            if(port.fieldName == nameof(Result)) {
                return Result;
            }
            return null; // Replace this
        }
    }
}
