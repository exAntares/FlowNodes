namespace XNode {
    public abstract class EventNode : MonoNode {
        [Output(editorIconName: "SceneLoadIn")] public Flow FlowOutput;

        public void TriggerFlow() {
            FlowUtils.TriggerFlow(Outputs, nameof(FlowNode.FlowOutput));
        }
    }
}
