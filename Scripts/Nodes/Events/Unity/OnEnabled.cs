using XNode;

namespace Events.UnityNative {
    [CreateNodeMenu("Events/"+nameof(OnEnabled), "Enable", "Awake", "Start")]
    public class OnEnabled : EventNode {

        public override void OnEnable() {
            base.OnEnable();
            TriggerFlow();
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
