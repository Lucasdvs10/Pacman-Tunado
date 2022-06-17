using UnityEngine;
using UnityEngine.InputSystem;

namespace GameScripts{
    public class GridAgentBehaviour : MonoBehaviour{
        [SerializeField] private GridBehaviour _gridBehaviour;
        [SerializeField] private Vector2Int _initialPosition;
        private GridAgent _gridAgent;
        private Vector2 _velocityDirection;
        
        private void Start() {
            _gridAgent = new GridAgent(_gridBehaviour.Grid, _initialPosition);
        }

        private void Update() {
            transform.position = _gridAgent.WorldPosition;
            
            MovePlayerInCurrentDirection();
        }
        
        [ContextMenu("Mover pra esquerda")]
        public void MoveLeft() {
            _gridAgent.MoveLeft();
        }
        
        [ContextMenu("Mover pra direita")]
        public void MoveRight() {
            _gridAgent.MoveRight();
        }
        
        [ContextMenu("Mover pra cima")]
        public void MoveUp() {
            _gridAgent.MoveUp();
        }
        
        [ContextMenu("Mover pra baixo")]
        public void MoveDown() {
            _gridAgent.MoveDown();
        }

        public void UpdateCurrentDirection(InputAction.CallbackContext ctx) {
            _velocityDirection = ctx.ReadValue<Vector2>().normalized;
        }
        
        private void MovePlayerInCurrentDirection() {
            if (_velocityDirection == Vector2.right) {
                MoveRight();
            }
            else if (_velocityDirection == Vector2.left) {
                MoveLeft();
            }
            else if (_velocityDirection == Vector2.up) {
                MoveUp();
            }
            else if (_velocityDirection == Vector2.down) {
                MoveDown();
            }
        }
        
        
    }
}