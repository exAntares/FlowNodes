using UnityEngine;
using XNode;

namespace Actions.UnityNative {
    [CreateNodeMenu("Random/" + nameof(GetRandomFloat), "Random", "Float")]
    public class GetRandomFloat : FlowNode {
        [Input] public float Min;
        [Input] public float Max;
        [Output] public float Result;

        public override void ExecuteNode() {
            var min = GetInputValue(nameof(Min), Min);
            var max = GetInputValue(nameof(Max), Max);
            Result = UnityEngine.Random.Range(min, max);
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            if(port.fieldName == nameof(Result)) {
                return Result;
            }
            return null; // Replace this
        }
    }
}
