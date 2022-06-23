using System.Collections.Generic;
using UnityEngine;

namespace GameScripts.GhostsPathFinding{
    public interface IPathCalculator{
        Queue<Vector2Int> SetPath(Vector2Int startPosition, Vector2Int endPosition);
    }
}