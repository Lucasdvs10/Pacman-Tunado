using GameScripts.ScriptableSingletons;
using UnityEngine;
using UnityEngine.AI;

namespace GameScripts.Ghosts.NavMesh{
    public class BlueNavMeshController : MonoBehaviour{
        public GameObject jogador;
        public SOVector2Singleton direcaoJogador;
        private NavMeshAgent _navMeshAgent;
        
        
        private void Awake() {
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;
        }

        public void SetPositionDestination(Vector2 destination) {
            _navMeshAgent.SetDestination(destination);
        }

        public void SetGameObjToFollow(GameObject gameObject) {
            jogador = gameObject;
        }
        
        private void Update() {
            SetPositionDestination(jogador.transform.position +
                                   (new Vector3(direcaoJogador.Value.x, direcaoJogador.Value.y, 0).normalized * 4) );
        }
    }
}