using UnityEngine;
using UnityEngine.UI;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("UI/"+ nameof(SetImage), "Set", "Image", "Sprite")]
    public class SetImage : FlowNode {
        [Input] public Image Target;
        [Input] public Sprite MySprite;

        public override void ExecuteNode() {
            var target = GetInputValue(nameof(Target), Target);
            var sprite = GetInputValue(nameof(MySprite), MySprite);
            target.sprite = sprite;
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            return null; // Replace this
        }
    }
}
