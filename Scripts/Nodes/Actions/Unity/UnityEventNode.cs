using UnityEngine.Events;
using XNode;

namespace HalfBlind.Nodes {
    [NodeWidth(400)]
    [CreateNodeMenu("Actions/" + nameof(UnityEventNode), "Event", "Unity")]
    public class UnityEventNode : FlowNode {
        public UnityEvent Target;

        public override void ExecuteNode() {
            Target.Invoke();
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            return null; // Replace this
        }
    }
}
