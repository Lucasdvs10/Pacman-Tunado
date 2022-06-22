using UnityEngine;

namespace GameScripts{
    [RequireComponent(typeof(FakePlayerMover))]
    public class PlayerFlagController : MonoBehaviour{
        private BaseMatrixGrid _playerGrid;
        private GameObject _playerGameobj;
        private Vector2Int _fakePlayerGridPosition;
        private PlayerGridAgentBehaviour _playerPlayerGridAgentBehaviour;
        private FakePlayerMover _fakePlayerMover;
        
        private void Awake() {
            _fakePlayerMover = GetComponent<FakePlayerMover>();
        }

        private void Start() {
            _playerGameobj = _fakePlayerMover.RealPlayerGameObj;
            _playerPlayerGridAgentBehaviour = _playerGameobj.GetComponent<PlayerGridAgentBehaviour>();
            _playerGrid = _playerPlayerGridAgentBehaviour.GridBehaviour.Grid;
            
        }

        private void Update() {
            _fakePlayerGridPosition = _playerGrid.WorldPosToGridPos(transform.position);

            if (_fakePlayerGridPosition == _playerPlayerGridAgentBehaviour.GetPositionInGrid) {
                _playerPlayerGridAgentBehaviour.TurnCanWalkOn();
            }
            else {
                _playerPlayerGridAgentBehaviour.TurnCanWalkOff();
            }
        }
    }
}