using XNode;

namespace HalfBlind {
    [NodeWidth(300)]
    [CreateNodeMenu("Events/" + nameof(OnAnimationEvent), "Animation", "Event")]
    public class OnAnimationEvent : EventNode {
        [Output] public string EventName;

        public void DoAnimationEvent(string eventName) {
            EventName = eventName;
            TriggerFlow();
        }

        public override object GetValue(NodePort port) {
            if (port.fieldName == nameof(EventName)) {
                return EventName;
            }

            return null;
        }
    }
}