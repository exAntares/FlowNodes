using UnityEngine;
using XNode;

namespace Data.UnityNative {
    public class IsActive : MonoNode {
        [Input] public GameObject Target;
        [Output] public bool Output;

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            var target = GetInputValue<GameObject>(nameof(Target), Target);
            if (port.fieldName == nameof(Output)) {
                return target ? target.activeSelf : false;
            }
            return null; // Replace this
        }
    }
}
