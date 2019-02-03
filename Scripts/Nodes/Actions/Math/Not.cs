using UnityEngine;
using XNode;

namespace Logic {
    public class Not : MonoNode {
        [Input] public bool Input;
        [Output] public bool Result;

        // Use this for initialization
        protected override void Init() {
            base.Init();
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            if (port.fieldName == nameof(Result)) {
                return !GetInputValue<bool>(nameof(Input), Input);
            }
            return null; // Replace this
        }
    }
}