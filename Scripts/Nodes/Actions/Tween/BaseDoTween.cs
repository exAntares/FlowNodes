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

        protected Tweener SetupTween(Tweener toSetup) {
            toSetup.SetDelay(DelaySeconds)
                .SetEase(Easing)
                .SetLoops(LoopsAmount);
            toSetup.onComplete += OnTweenComplete;
            toSetup.onStepComplete += OnStepComplete;
            return toSetup;
        }

        // Return the correct value of an output port when requested
        public override object GetValue(NodePort port) {
            return null; // Replace this
        }

        protected abstract void OnTweenComplete();
        protected abstract void OnStepComplete();
    }
}