using UnityEngine;
using XNode;

namespace Data.UnityNative {
    public class GameObjectVar : MonoNode {
        public GameObject Target;
        [Output] public GameObject GoOutput;

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            if (port.fieldName == nameof(GoOutput)) {
                return Target;
            }
            return null; // Replace this
        }
    }
}
