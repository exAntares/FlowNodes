using UnityEngine;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Math/"+nameof(CompareFloat), "float", "compare")]
    public class CompareFloat : MonoNode {
        public enum Operation {
            LessThan,
            EqualOrLessThan,
            Equal,
            EqualOrGreaterThan,
            GreaterThan,
        }

        [Input] public float InputA;
        public Operation MyOperation;
        [Input] public float InputB;
        [Output] public bool Result;

        // Use this for initialization
        protected override void Init() {
            base.Init();
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            if (port.fieldName == nameof(Result)) {
                var a = GetInputValue<float>(nameof(InputA), InputA);
                var b = GetInputValue<float>(nameof(InputB), InputB);
                switch (MyOperation) {
                    case Operation.Equal:
                        return (a - b) * (a - b) <= 0.0001f;
                    case Operation.EqualOrGreaterThan:
                        return a >= b;
                    case Operation.EqualOrLessThan:
                        return a <= b;
                    case Operation.GreaterThan:
                        return a > b;
                    case Operation.LessThan:
                        return a < b;
                }
            }
            return null; // Replace this
        }
    }
}
