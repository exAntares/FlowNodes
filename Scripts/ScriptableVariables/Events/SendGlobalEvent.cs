using HalfBlind.ScriptableVariables;
using XNode;

namespace HalfBlind.Nodes {
    [NodeWidth(300)]
    [CreateNodeMenu("Events/"+nameof(SendGlobalEvent), "Trigger", "Global", "Event")]
    public class SendGlobalEvent : FlowNode {
        public ScriptableGameEvent GameEvent;

        public override object GetValue(NodePort port) {
            return null;
        }

        public override void ExecuteNode() {
            GameEvent.SendEvent();
        }
    }
}
