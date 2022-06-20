using GameScripts.GameEvent;
using GameScripts.ScriptableSingletons;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameScripts{
    public class PlayerGridAgentBehaviour : BaseEventEmmiter{
        [SerializeField] private GridBehaviour _gridBehaviour;
        [SerializeField] private Vector2Int _initialPosition;
       
        private GridAgent _gridAgent;
        private bool _walkFlag;
        private Vector2 _inputDirection;

        public SOSingleVector2 singleVector2; 
        
        private void Start() {
            _gridAgent = new GridAgent(_gridBehaviour.Grid, _initialPosition);
            _gridAgent.OnPositionChangedEvent += InvokeEvent;
        }

        private void Update() {
            transform.position = _gridAgent.WorldPosition;
            MoveInGrid(InputDirection);
        }

        public void SetInputDirection(InputAction.CallbackContext ctx) {
            if(ctx.started) return;
            InputDirection = ctx.ReadValue<Vector2>();
        }
        
        public void MoveInGrid(Vector2 direction) {
            _gridAgent.Move(new Vector2Int((int)-direction.y, (int)direction.x));
        }

        private void OnDisable() {
            _gridAgent.OnPositionChangedEvent -= InvokeEvent;
        }
        
        public void TurnCanWalkOn() {
            _gridAgent.CanWalk = true;
        }
        public void TurnCanWalkOff() {
            _gridAgent.CanWalk = false;
        }

        public GridBehaviour GridBehaviour => _gridBehaviour;
        public Vector2Int GetPositionInGrid => _gridAgent.PositionInGrid;

        public Vector2 InputDirection {
            get => _inputDirection;
            set {
                _inputDirection = value;
                singleVector2.Value = value;
            }
        }
    }
}