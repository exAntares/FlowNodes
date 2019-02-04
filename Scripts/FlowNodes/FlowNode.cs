namespace XNode {
    public abstract class FlowNode : MonoNode {
        [Input(editorIconName: "SceneLoadOut")] public Flow FlowInput;
        [Output(editorIconName: "SceneLoadIn")] public Flow FlowOutput;

        public virtual void TriggerFlow() {
            FlowUtils.TriggerFlow(Outputs, nameof(FlowOutput));
        }

        public abstract void ExecuteNode();
    }
}
