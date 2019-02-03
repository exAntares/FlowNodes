using UnityEngine;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Utils/"+nameof(GetUniqueDeviceIdentifier), "Unique", "Identifier")]
    public class GetUniqueDeviceIdentifier : MonoNode {
        [Output] public string deviceId;

        public override object GetValue(NodePort port) {
            return port.fieldName == nameof(deviceId) ? SystemInfo.deviceUniqueIdentifier : null;
        }
    }
}