namespace XNode {
    public abstract class EventNode : MonoNode {
        [Output] public Flow FlowOutput;

        public void TriggerFlow() {
            FlowUtils.TriggerFlow(Outputs);
        }
    }
}
