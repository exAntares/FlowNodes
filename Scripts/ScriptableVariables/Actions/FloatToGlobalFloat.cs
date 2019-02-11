using HalfBlind.ScriptableVariables;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Variables/Actions/"+nameof(FloatToGlobalFloat), "set")]
    public class FloatToGlobalFloat : FlowNode {
        [Input] public float Input;
        [Input] public GlobalFloat Target;

        public override void ExecuteNode() {
            var target = GetInputValue<GlobalFloat>(nameof(Target), Target);
            target.Value = GetInputValue<float>(nameof(Input), Input);
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
