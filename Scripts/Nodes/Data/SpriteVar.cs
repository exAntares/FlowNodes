using UnityEngine;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Variables/" + nameof(SpriteVar))]
    public class SpriteVar : MonoNode {
        public Sprite Value;
        [Output] public Sprite Output;

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            if (port.fieldName == nameof(Output)) {
                return Value;
            }
            return null; // Replace this
        }
    }
}
