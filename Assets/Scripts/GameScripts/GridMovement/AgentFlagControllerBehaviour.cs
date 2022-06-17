using UnityEngine;

namespace GameScripts{
    public class AgentFlagControllerBehaviour : MonoBehaviour{
        private GridAgentBehaviour _agentBehaviour;
        private FakePlayerPositionManager _fakePlayerPositionManager;

        private void Awake() {
            _agentBehaviour = GetComponentInParent<GridAgentBehaviour>();
            _fakePlayerPositionManager = GetComponent<FakePlayerPositionManager>();
        }

        private void Update() {
            if (!_fakePlayerPositionManager.IsInRealPosition) {
                TurnOnFlag();
            }
            else {
                TurnOffFlag();
            }
        }

        public void TurnOffFlag() {
            _agentBehaviour.TurnFlagOff();
        }

        public void TurnOnFlag() {
            _agentBehaviour.TurnFlagOn();
        }
        
    }
}