using System;
using System.Collections.Generic;

namespace XNode {
    public abstract class FlowNode : MonoNode {
        [Input] public Flow FlowInput;
        [Output] public Flow FlowOutput;

        public void TriggerFlow() {
            foreach (var output in Outputs) {
                if(output.fieldName == nameof(FlowOutput)) {
                    List<NodePort> connections = output.GetConnections();
                    for (int i = 0; i < connections.Count; i++) {
                        var inputPort = connections[i];
                        if(inputPort.fieldName == nameof(FlowInput)) {
                            var flowNode = inputPort.node as FlowNode;
                            if (flowNode) {
                                flowNode.ExecuteNode();
                            }
                        }
                    }
                }
            }
        }

        public abstract void ExecuteNode();
    }
}
