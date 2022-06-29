using UnityEngine;

namespace GameScripts.GhostsPathFinding.SOTargetDefiners{
    [CreateAssetMenu(fileName = "ChasePlayerDefiner", menuName = "Target Definers/Chase Player")]
    public class SOChasePlayerTD : SOBaseTargetDefiner{
        public override Vector2Int DefineTargetPosition() {
            return PlayerPosition.Value;
        }
    }
}