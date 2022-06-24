using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.GhostsPathFinding.SOTargetDefiners{
    [CreateAssetMenu(fileName = "BeAheadPlayer", menuName = "Target Definers/Be Ahead Player", order = 0)]
    public class SOBeAheadPlayerTD : SOBaseTargertDefiner{
        public SOSingleVector2 PlayerDirection;
        public override Vector2Int DefineTargetPosition() {
            var direction = new Vector2Int((int)-PlayerDirection.Value.y, (int)PlayerDirection.Value.x);
            var vectorToReturn = PlayerPosition.Value + direction * 3;
            return vectorToReturn;
        }
    }
}