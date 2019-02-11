using HalfBlind.ScriptableVariables;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Variables/Actions/"+nameof(BoolToGlobalBool), "set")]
    public class BoolToGlobalBool : FlowNode {
        [Input] public bool Input;
        [Input] public GlobalBoolean Target;

        public override void ExecuteNode() {
            var target = GetInputValue<GlobalBoolean>(nameof(Target), Target);
            target.Value = GetInputValue<bool>(nameof(Input), Input);
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
