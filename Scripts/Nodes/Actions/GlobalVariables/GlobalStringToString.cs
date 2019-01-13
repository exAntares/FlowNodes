using LRCore;
using XNode;

namespace Actions.GlobalVariables {
    public class GlobalStringToString : MonoNode {
        public GlobalString Input;
        [Output] public string Output;

        public override object GetValue(NodePort port) {
            if(port.fieldName == nameof(Output)) {
                return Input?.Value;
            }
            return null;
        }
    }
}
