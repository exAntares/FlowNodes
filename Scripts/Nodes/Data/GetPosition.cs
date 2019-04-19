using UnityEngine;
using XNode;

namespace Data.UnityNative {
    [CreateNodeMenu("GameObject/"+nameof(GetPosition), "transform")]
    public class GetPosition : MonoNode {
        [Input] public GameObject Target;
        [Output] public Vector3 PositionVector3;
        [Output] public Vector3 PositionX;
        [Output] public Vector3 PositionY;
        [Output] public Vector3 PositionZ;

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            var target = GetInputValue<GameObject>(nameof(Target), Target);
            if(target == null) {
                return null;
            }

            if (port.fieldName == nameof(PositionVector3)) {
                return target.transform.position;
            }

            if (port.fieldName == nameof(PositionX)) {
                return target.transform.position.x;
            }

            if (port.fieldName == nameof(PositionY)) {
                return target.transform.position.y;
            }

            if (port.fieldName == nameof(PositionZ)) {
                return target.transform.position.z;
            }

            return null; // Replace this
        }
    }
}
