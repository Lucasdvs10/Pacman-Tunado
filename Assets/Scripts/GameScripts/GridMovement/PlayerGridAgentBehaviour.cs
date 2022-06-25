using System.Collections;
using GameScripts.GameEvent;
using GameScripts.SOSingletons;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;

namespace GameScripts{
    public class PlayerGridAgentBehaviour : BaseEventEmmiter{
        [SerializeField] private GridBehaviour _gridBehaviour;
        [SerializeField] private Vector2Int _initialPosition;
       
        public SOSingleVector2Int GridPositionSingleton;
        public SOSingleVector2 PlayerDirection;
        
        private GridAgent _gridAgent;
        private bool _walkFlag;
        private Vector2 _inputDirection;
        
        private void Start() {
            _gridAgent = new GridAgent(_gridBehaviour.Grid, _initialPosition);
            _gridAgent.OnPositionChangedEvent += InvokeEvent;
            
            transform.position = _gridAgent.WorldPosition;
            StartCoroutine(MoveInGridCoroutine());
        }



        public override void InvokeEvent() {
            transform.position = _gridAgent.WorldPosition;
            GridPositionSingleton.Value = _gridAgent.PositionInGrid;
            base.InvokeEvent();
        }

        public void SetInputDirection(InputAction.CallbackContext ctx) {
            if(ctx.started) return;
            InputDirection = ctx.ReadValue<Vector2>();
        }
        
        public IEnumerator MoveInGridCoroutine() {
            while(true){
                if(_inputDirection != Vector2.zero) {
                    _gridAgent.Move(new Vector2Int((int) -_inputDirection.y, (int) _inputDirection.x));
                    yield return new WaitForSeconds(0.2f);
                }
                else
                    yield return null;
            }
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
                PlayerDirection.Value = value;
            }
        }
    }
}