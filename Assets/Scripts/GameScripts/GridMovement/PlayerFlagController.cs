using UnityEngine;

namespace GameScripts{
    [RequireComponent(typeof(FakePlayerMover))]
    public class PlayerFlagController : MonoBehaviour{
        private MatrixGrid _playerGrid;
        private GameObject _playerGameobj;
        private Vector2Int _fakePlayerGridPosition;
        private GridAgentBehaviour _playerGridAgentBehaviour;
        private FakePlayerMover _fakePlayerMover;
        
        private void Awake() {
            _fakePlayerMover = GetComponent<FakePlayerMover>();
        }

        private void Start() {
            _playerGameobj = _fakePlayerMover.RealPlayerGameObj;
            _playerGridAgentBehaviour = _playerGameobj.GetComponent<GridAgentBehaviour>();
            _playerGrid = _playerGridAgentBehaviour.GridBehaviour.Grid;
            
        }

        private void Update() {
            _fakePlayerGridPosition = _playerGrid.WorldPosToGridPos(transform.position);

            if (_fakePlayerGridPosition == _playerGridAgentBehaviour.GetPositionInGrid) {
                _playerGridAgentBehaviour.TurnCanWalkOn();
            }
            else {
                _playerGridAgentBehaviour.TurnCanWalkOff();
            }
        }
    }
}