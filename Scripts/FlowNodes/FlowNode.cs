using System.Collections.Generic;

namespace XNode {
    public abstract class FlowNode : MonoNode {
        [Input] public Flow FlowInput;
        [Output] public Flow FlowOutput;

        public void TriggerFlow() {
            FlowUtils.TriggerFlow(Outputs);
        }

        public abstract void ExecuteNode();
    }

    public static class FlowUtils {
        public static void TriggerFlow(IEnumerable<NodePort> Outputs) {
            var connectedInputPorts = new List<FlowNode>();
            foreach (var output in Outputs) {
                if (output.fieldName == nameof(FlowNode.FlowOutput)) {
                    List<NodePort> connections = output.GetConnections();
                    for (int i = 0; i < connections.Count; i++) {
                        var inputPort = connections[i];
                        if (inputPort.fieldName == nameof(FlowNode.FlowInput)) {
                            var flowNode = inputPort.node as FlowNode;
                            if (flowNode) {
                                connectedInputPorts.Add(flowNode);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < connectedInputPorts.Count; i++) {
                var flowNode = connectedInputPorts[i];
                flowNode.ExecuteNode();
            }

            for (int i = 0; i < connectedInputPorts.Count; i++) {
                var flowNode = connectedInputPorts[i];
                TriggerFlow(flowNode.Outputs);
            }
        }
    }
}
