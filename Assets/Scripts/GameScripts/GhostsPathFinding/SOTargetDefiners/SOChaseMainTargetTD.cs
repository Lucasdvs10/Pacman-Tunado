using UnityEngine;

namespace GameScripts.GhostsPathFinding.SOTargetDefiners{
    [CreateAssetMenu(fileName = "ChasePlayerDefiner", menuName = "Target Definers/Chase Main Target")]
    public class SOChaseMainTargetTD : SOBaseTargetDefiner{
        public override Vector2Int DefineTargetPosition() {
            return MainTargetPosition.Value;
        }
    }
}