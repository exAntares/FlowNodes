using HalfBlind.ScriptableVariables;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Variables/Actions/"+nameof(StringToGlobalString), "set")]
    public class StringToGlobalString : FlowNode {
        [Input] public string Input;
        [Input] public GlobalString Target;

        public override void ExecuteNode() {
            var target = GetInputValue<GlobalString>(nameof(Target), Target);
            target.Value = GetInputValue<string>(nameof(Input), Input);
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
