using HalfBlind.ScriptableVariables;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Variables/Actions/"+nameof(FloatToGlobalFloat))]
    public class FloatToGlobalFloat : FlowNode {
        [Input] public float Input;
        public GlobalFloat Target;

        public override void ExecuteNode() {
            Target.Value = GetInputValue<float>(nameof(Input), Input);
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
