using UnityEngine;

namespace GameScripts{
    public class GridAgentBehaviour : MonoBehaviour{
        [SerializeField] private GridBehaviour _gridBehaviour;
        [SerializeField] private Vector2Int _initialPosition;
        private GridAgent _gridAgent;

        
        private void Start() {
            _gridAgent = new GridAgent(_gridBehaviour.Grid, _initialPosition);
        }

        private void Update() {
            transform.position = _gridAgent.WorldPosition;
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

    }
}