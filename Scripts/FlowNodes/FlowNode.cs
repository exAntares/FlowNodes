namespace XNode {
    public abstract class FlowNode : MonoNode {
        [Input] public Flow FlowInput;
        [Output] public Flow FlowOutput;

        public virtual void TriggerFlow() {
            FlowUtils.TriggerFlow(Outputs, nameof(FlowOutput));
        }

        public abstract void ExecuteNode();
    }
}
