using UnityEngine;
using UnityEngine.UI;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("UI/Input/"+nameof(ReadInputFieldText), "Input", "Field")]
    public class ReadInputFieldText : MonoNode {
        [Input] public InputField inputField;
        [Output] public string fieldText;

        public override object GetValue(NodePort port) {
            if (inputField != null) {
                return inputField.text;
            }

            return string.Empty;
        }
    }
}
