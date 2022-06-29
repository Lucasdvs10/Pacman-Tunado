using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.GhostsPathFinding.SOTargetDefiners{
    [CreateAssetMenu(fileName = "FleeFromTargets", menuName = "Target Definers/Flee From Targets")]
    public class SOFleeFromTargets : SOBaseTargetDefiner{
        [SerializeField] private List<SOSingleVector2Int> _targetsPositionsList;
        [SerializeField] private SOAvaibleCellsSingleton _avaibleCellsSingleton;

        public override Vector2Int DefineTargetPosition() {
            List<Vector2Int> _farPointsList = new List<Vector2Int>();

            foreach (var target in _targetsPositionsList) {
                float farestDistance = 0f;
                Vector2Int position = Vector2Int.zero;

                foreach (Vector2Int cellPosition in _avaibleCellsSingleton.CellsDict.Keys) {
                    var distance = Vector2Int.Distance(cellPosition, target.Value);
                    
                    if (distance > farestDistance) {
                        farestDistance = distance;
                        position = cellPosition;
                    }
                }

                if (_avaibleCellsSingleton.CellsDict.ContainsKey(position)) {
                    _farPointsList.Add(position);
                }
            }
            return GetMeanPosition(_farPointsList);
        }

        //todo:Essa parte aqui merece uma refatorada. Essa função tá fazendo muita coisa
        private Vector2Int GetMeanPosition(List<Vector2Int> positionsList) {
            int sumX = 0;
            int sumY = 0;
            foreach (var position in positionsList) {
                sumX += position.x;
                sumY += position.y;
            }

            sumX /= positionsList.Count;
            sumY /= positionsList.Count;

            var farestPosition = new Vector2Int(sumX, sumY);

            if (_avaibleCellsSingleton.CellsDict.ContainsKey(farestPosition)) {
                return farestPosition;
            }
            float minDistance = Mathf.Infinity;
            foreach (var cells in _avaibleCellsSingleton.CellsDict.Values) {
                var distance = Mathf.Abs(cells.GridPosition.x - farestPosition.x) +
                               Mathf.Abs(cells.GridPosition.y - farestPosition.y);
                if (distance < minDistance) {
                    minDistance = distance;
                    farestPosition = cells.GridPosition;
                }
            }
            return farestPosition;
        }
    }
}