using XNode;

namespace HalfBlind.Nodes {
    [NodeWidth(150)]
    [CreateNodeMenu("Branch/"+nameof(BoolBranch), "if", "bool", "branch", "switch")]
    public class BoolBranch : FlowNode {
        [Input] public bool Bool;
        [Output] public Flow FalseOutput;

        public override void TriggerFlow() {
            var outputTriggerName = GetInputValue<bool>(nameof(Bool), Bool) ? nameof(FlowNode.FlowOutput) : nameof(FalseOutput);
            FlowUtils.TriggerFlow(Outputs, outputTriggerName);
        }

        public override void ExecuteNode() {
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
