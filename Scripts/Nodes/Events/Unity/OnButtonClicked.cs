using UnityEngine.UI;
using XNode;

namespace Events.UnityNative {
    public class OnButtonClicked : EventNode {
        [Input] public Button MyButton;

        // Use this for initialization
        protected override void Init() {
            base.Init();
            MyButton?.onClick.AddListener(OnMyButtonClicked);
        }

        private void OnMyButtonClicked() {
            TriggerFlow();
        }

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}
