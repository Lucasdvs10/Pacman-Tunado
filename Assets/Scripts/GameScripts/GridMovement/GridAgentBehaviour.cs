using GameScripts.GameEvent;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameScripts{
    public class GridAgentBehaviour : BaseEventEmmiter{
        [SerializeField] private GridBehaviour _gridBehaviour;
        [SerializeField] private Vector2Int _initialPosition;
       
        private GridAgent _gridAgent;
        private bool _walkFlag;
        private Vector2 _inputDirection;
        
        private void Start() {
            _gridAgent = new GridAgent(_gridBehaviour.Grid, _initialPosition);
            _gridAgent.OnPositionChangedEvent += InvokeEvent;
        }

        private void Update() {
            transform.position = _gridAgent.WorldPosition;
            MoveInGrid(_inputDirection);
        }

        public void SetInputDirection(InputAction.CallbackContext ctx) {
            if(ctx.started) return;
            _inputDirection = ctx.ReadValue<Vector2>();
        }
        
        public void MoveInGrid(Vector2 direction) {
            _gridAgent.Move(new Vector2Int((int)-direction.y, (int)direction.x));
        }

        private void OnDisable() {
            _gridAgent.OnPositionChangedEvent -= InvokeEvent;
        }
        
        public void TurnCantWalkOn() {
            _gridAgent.CantWalk = true;
        }
        public void TurnCantWalkOff() {
            _gridAgent.CantWalk = false;
        }

        public Vector2Int GetPositionInGrid => _gridAgent.PositionInGrid;

    }
}