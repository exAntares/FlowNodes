using XNode;

namespace Events.UnityNative {
    [CreateNodeMenu("Events/OnStart", "Awake", "Start", "Init")]
    public class OnStart : EventNode {
        private void Start() {
            TriggerFlow();
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
