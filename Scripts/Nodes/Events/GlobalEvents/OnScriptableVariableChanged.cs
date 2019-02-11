using HalfBlind.ScriptableVariables;
using XNode;

namespace HalfBlind.Nodes {
    [NodeWidth(300)]
    [CreateNodeMenu("Events/"+nameof(OnScriptableVariableChanged), "Global")]
    public class OnScriptableVariableChanged : EventNode {
        public ScriptableVariable Variable;
        [Output] public int Value;

        protected override void Init() {
            base.Init();
            if(Variable != null) {
                Variable.OnValueChanged += TriggerFlow;
            }
        }

        private void OnDestroy() {
            if (Variable != null) {
                Variable.OnValueChanged -= TriggerFlow;
            }
        }

        public override object GetValue(NodePort port) {
            if(port.fieldName == nameof(Value)) {
                return Variable.GetValue();
            }
            return null;
        }
    }
}
