using UnityEngine;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Random/" + nameof(RandomBranch), "Random", "branch")]
    public class RandomBranch : FlowNode {
        [Output(instancePortList: true)] public int[] FlowOutputWeights;

        public override void ExecuteNode() {
        }

        public override void TriggerFlow() {
            if(FlowOutputWeights.Length <= 0) {
                return;
            }

            int totalWeight = 0;
            for (int i = 0; i < FlowOutputWeights.Length; i++) {
                totalWeight += Mathf.Abs(FlowOutputWeights[i]);
            }

            int randomValue = Random.Range(0, totalWeight) + 1;

            for (int i = 0; i < FlowOutputWeights.Length; i++) {
                randomValue -= Mathf.Abs(FlowOutputWeights[i]);
                if(randomValue <= 0) {
                    FlowUtils.TriggerFlow(Outputs, $"{nameof(FlowOutputWeights)} {i}");
                    return;
                }
            }
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            return null; // Replace this
        }
    }
}
