using HalfBlind.ScriptableVariables;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Variables/"+nameof(GlobalFloatToFloat))]
    public class GlobalFloatToFloat : MonoNode {
        public GlobalFloat Input;
        [Output] public float Output;

        public override object GetValue(NodePort port) {
            if(port.fieldName == nameof(Output)) {
                return Input?.Value;
            }
            return null;
        }
    }
}
