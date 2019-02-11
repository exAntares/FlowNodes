using HalfBlind.ScriptableVariables;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Variables/"+nameof(GlobalStringToString), "global", "string", "to", "set")]
    public class GlobalStringToString : MonoNode {
        public GlobalString Input;
        [Output] public string Output;

        public override object GetValue(NodePort port) {
            if(port.fieldName == nameof(Output)) {
                return Input?.Value;
            }
            return null;
        }
    }
}
