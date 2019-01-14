using HalfBlind.ScriptableVariables;
using XNode;

namespace Actions.GlobalVariables {
    public class StringToGlobalString : FlowNode {
        [Input] public string Input;
        public GlobalString Result;

        public override void ExecuteNode() {
            Result.Value = GetInputValue<string>(nameof(Input), Input);
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
