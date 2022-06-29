using System;
using GameScripts.SOSingletons;
using UnityEngine;
using Random = System.Random;

namespace GameScripts.GhostsPathFinding.SOTargetDefiners{
    [CreateAssetMenu(fileName = "WalkRandomlyTD", menuName = "Target Definers/Walk Randomly")]
    public class SOWalkRandomlyTD : SOBaseTargetDefiner{
        [SerializeField] private SOSingleVector2Int _gridSizes;
        public override Vector2Int DefineTargetPosition() {
            int rowPosition;
            int columnPosition;
            var rd = new Random();

            rowPosition = rd.Next(0, _gridSizes.Value.x);
            columnPosition = rd.Next(0, _gridSizes.Value.y);

            return new Vector2Int(rowPosition, columnPosition);
        }
    }
}