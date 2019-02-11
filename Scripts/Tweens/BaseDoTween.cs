using DG.Tweening;
using XNode;

namespace HalfBlind.Nodes {
    public abstract class BaseDoTween : FlowNode {
        public float Duration = 1;
        public float DelaySeconds = 0;
        public int LoopsAmount;
        public LoopType Loop;
        public Ease Easing = Ease.Linear;

        protected Tweener tween;

        public override void TriggerFlow() {
            //base.TriggerFlow();
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            return null; // Replace this
        }

        protected Tweener SetupTween(Tweener toSetup) {
            toSetup.SetDelay(DelaySeconds)
                .SetEase(Easing)
                .SetLoops(LoopsAmount, Loop);
            toSetup.onComplete += OnTweenComplete;
            return toSetup;
        }

        protected void OnTweenComplete() {
            base.TriggerFlow();
            tween = null;
        }
    }
}