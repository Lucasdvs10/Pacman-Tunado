using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GameScripts.Ghosts.NavMesh{
    public class GoldNavMeshController : MonoBehaviour{
        private NavMeshAgent _navMeshAgent;
        public GameObject[] _allGameObjects;
        private Vector2 _targetPosition;
        public GridBehaviour Grid;
        
        
        private void Awake() {
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;
        }

        private void Update() {
            List<Vector2> _allMaximumDistances = new List<Vector2>();
            foreach (var obj in _allGameObjects) {
                var maxDistance = 0f;
                var maxPosition = new Vector2();
                foreach (var cell in Grid.Grid.CellsMatrix) {
                    var currentDistance = Vector2.Distance(obj.transform.position, cell.WorldPosition);
                    if (currentDistance > maxDistance && cell.Walkable) {
                        maxDistance = currentDistance;
                        maxPosition = cell.WorldPosition;
                    }
                }
                
                _allMaximumDistances.Add(maxPosition);
            }

            float xPos = 0;
            float yPos = 0;
            foreach (var postion in _allMaximumDistances) {
                xPos += postion.x;
                yPos += postion.y;
            }

            xPos /= _allMaximumDistances.Count;
            yPos /= _allMaximumDistances.Count;

            xPos = Mathf.Clamp(xPos, Grid.Grid.CellsMatrix[0,0].WorldPosition.x,
                Grid.Grid.CellsMatrix[31,31].WorldPosition.x);
            
            yPos = Mathf.Clamp(yPos, Grid.Grid.CellsMatrix[31,31].WorldPosition.y,
                Grid.Grid.CellsMatrix[0,0].WorldPosition.y);

            _targetPosition = new Vector2(xPos, yPos);
            
            _navMeshAgent.SetDestination(_targetPosition);
        }
    }
}