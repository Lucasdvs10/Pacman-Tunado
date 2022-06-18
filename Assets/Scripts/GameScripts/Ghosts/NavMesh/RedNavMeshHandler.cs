using System;
using UnityEngine;
using UnityEngine.AI;

namespace GameScripts.Ghosts.NavMesh{
    [RequireComponent(typeof(NavMeshAgent))]
    public class RedNavMeshHandler : MonoBehaviour, IPathFinderController{
        public GameObject jogador;
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
            SetPositionDestination(jogador.transform.position);
        }
    }
}