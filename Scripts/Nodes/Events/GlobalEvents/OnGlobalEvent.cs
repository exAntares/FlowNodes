using HalfBlind.ScriptableVariables;
using XNode;

namespace Events.Global {
    public class OnGlobalEvent : EventNode {
        public ScriptableGameEvent GameEvent;

        protected override void Init() {
            base.Init();
            GameEvent?.AddListener(TriggerFlow);
        }

        private void OnDestroy() {
            GameEvent?.RemoveListener(TriggerFlow);
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
