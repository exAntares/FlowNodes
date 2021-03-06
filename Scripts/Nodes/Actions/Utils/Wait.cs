﻿using System.Threading.Tasks;
using UnityEngine;
using XNode;

namespace HalfBlind.Nodes {
    [CreateNodeMenu("Utils/Wait", "Wait")]
    public class Wait : FlowNode {
        [Input] public float WaitSeconds;

        public override void TriggerFlow() {
            //base.TriggerFlow();
        }

        public override async void ExecuteNode() {
            var secondsToWait = GetInputValue(nameof(WaitSeconds), WaitSeconds);
            if(secondsToWait > 0) {
                await DoWait((int)(secondsToWait * 1000));
            }
        }

        public async Task DoWait(int waitMilliseconds) {
            await Task.Delay(waitMilliseconds);
            base.TriggerFlow();
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            return null; // Replace this
        }
    }
}
