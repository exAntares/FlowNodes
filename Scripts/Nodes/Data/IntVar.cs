using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Variables/" + nameof(IntVar))]
    public class IntVar : MonoNode {
        public int Value;
        [Output] public int Output;

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            if (port.fieldName == nameof(Output)) {
                return Value;
            }
            return null; // Replace this
        }
    }
}
