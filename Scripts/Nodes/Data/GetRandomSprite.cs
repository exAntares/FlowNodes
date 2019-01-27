using UnityEngine;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Random/" + nameof(GetRandomSprite), "Random", "Sprite")]
    public class GetRandomSprite : MonoNode {
        [Input] public Sprite[] Sprites;
        [Output] public Sprite Output;

        public override object GetValue(NodePort port) {
            if(port.fieldName == nameof(Output)) {
                var sprites = GetInputValue(nameof(Sprites), Sprites);
                if (sprites != null && sprites.Length > 0) {
                    var index = Random.Range(0, sprites.Length);
                    return sprites[index];
                }
            }
            return null;
        }
    }
}
