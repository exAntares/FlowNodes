using UnityEngine;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("GameObject/"+nameof(DestroyObject))]
    public class DestroyObject : FlowNode {
        [Input(editorIconName: "d_Prefab Icon", shouldTint: false)]
        public GameObject Target;

        public override void ExecuteNode() {
            var toDestroy = GetInputValue<GameObject>(nameof(Target), Target);
            Destroy(toDestroy);
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
