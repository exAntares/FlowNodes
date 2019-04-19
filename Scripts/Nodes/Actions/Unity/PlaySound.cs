using UnityEngine;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Audio/"+nameof(PlaySound), "sfx", "music")]
    public class PlaySound : FlowNode {
        [Input] public AudioClip Audio;
        [Input] public Vector3 TargetPosition;
        [Input] public float Volume = 1;

        public override void ExecuteNode() {
            var audio = GetInputValue<AudioClip>(nameof(Audio), Audio);
            var position = GetInputValue<Vector3>(nameof(TargetPosition), TargetPosition);
            var volume = GetInputValue<float>(nameof(Volume), Volume);
            AudioSource.PlayClipAtPoint(audio, position, volume);
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
