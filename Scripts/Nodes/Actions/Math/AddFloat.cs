using UnityEngine;
using XNode;

namespace Math {
    public class AddFloat : MonoNode {
        public enum Operation {
            Add,
            Substract,
            Multiply,
            Divide,
        }

        [Input] public float FloatA;
        [Input] public float FloatB;
        public Operation MyOperation;
        [Output] public float Result;

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            if (port.fieldName == nameof(Result)) {
                var a = GetInputValue<float>(nameof(FloatA), FloatA);
                var b = GetInputValue<float>(nameof(FloatB), FloatB);
                switch (MyOperation) {
                    case Operation.Add:
                        return a + b;
                    case Operation.Substract:
                        return a - b;
                    case Operation.Multiply:
                        return a * b;
                    case Operation.Divide:
                        return a / b;
                }
            }
            return null; // Replace this
        }
    }
}