using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Variables/"+nameof(IsStringNullOrEmpty), "string", "null", "empty")]
    public class IsStringNullOrEmpty : MonoNode {
        [Input] public string inputString;
        [Output] public bool isNull;

        public override object GetValue(NodePort port) {
            if (port.fieldName == nameof(isNull)) {
                var inputValue = GetInputValue(nameof(inputString), inputString);
                var isNullOrEmpty = string.IsNullOrEmpty(inputValue);
                return isNullOrEmpty;
            }

            return null;
        }
    }
}