using XNode;

namespace Data.UnityNative {
    public class StringVar : MonoNode {
        public string Value;
        [Output] public string Output;

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            if (port.fieldName == nameof(Output)) {
                return Value;
            }
            return null; // Replace this
        }
    }
}
