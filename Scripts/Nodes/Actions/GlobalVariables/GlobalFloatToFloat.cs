using LRCore;
using XNode;

namespace Actions.GlobalVariables {
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
