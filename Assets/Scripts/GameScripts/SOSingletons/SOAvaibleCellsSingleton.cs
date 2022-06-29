using System.Collections.Generic;
using UnityEngine;

namespace GameScripts.SOSingletons{
    [CreateAssetMenu(fileName = "AvaibleCells", menuName = "Singletons/Avaible Celss")]
    public class SOAvaibleCellsSingleton : ScriptableObject{
        public Dictionary<Vector2Int, GridCell> CellsDict = new Dictionary<Vector2Int, GridCell>();
    }
}