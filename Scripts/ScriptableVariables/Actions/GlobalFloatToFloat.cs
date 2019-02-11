using HalfBlind.ScriptableVariables;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Variables/"+nameof(GlobalFloatToFloat), "Set")]
    public class GlobalFloatToFloat : MonoNode {
        [Input] public GlobalFloat Input;
        [Output] public float Output;

        public override object GetValue(NodePort port) {
            if(port.fieldName == nameof(Output)) {
                var input = GetInputValue<GlobalFloat>(nameof(Input), Input);
                return input?.Value;
            }
            return null;
        }
    }
}
