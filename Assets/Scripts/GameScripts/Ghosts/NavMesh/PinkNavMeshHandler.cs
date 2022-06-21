using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

namespace GameScripts.Ghosts.NavMesh{
    public class PinkNavMeshHandler : MonoBehaviour{
        private NavMeshAgent _navMeshAgent;
        public GridBehaviour Grid;
        private List<GridCell> _gridCellsList = new List<GridCell>();


        private void Awake() {
            _navMeshAgent = GetComponent<NavMeshAgent>();

            _navMeshAgent.updateRotation = false;
            _navMeshAgent.updateUpAxis = false;
        }

        private void Start() {
            foreach (var cell in Grid.Grid.CellsMatrix) {
                if(cell.Walkable)
                    _gridCellsList.Add(cell);
            }
            
            StartCoroutine(RandomPositionCO());
        }

        private IEnumerator RandomPositionCO() {
            while(true){
                Vector3 position;
                
                   
                var random = new Random();
                var index = random.Next(0, _gridCellsList.Count);


                var cell = _gridCellsList[index];
                position = cell.WorldPosition;
                
                _navMeshAgent.SetDestination(position);
                
                print(cell.GridPosition);

                yield return new WaitForSeconds(6f);
            }
        }
        
    }
}