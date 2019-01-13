using LRCore;
using XNode;

namespace Actions.GlobalVariables {
    public class FloatToGlobalFloat : FlowNode {
        [Input] public float Input;
        public GlobalFloat Target;

        public override void ExecuteNode() {
            UnityEngine.Debug.Log("FloatToGlobalFloat ExecuteNode");
            Target.Value = GetInputValue<float>(nameof(Input), Input);
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
