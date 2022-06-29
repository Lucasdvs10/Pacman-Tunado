using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.GhostsPathFinding.SOTargetDefiners{
    public abstract class SOBaseTargetDefiner : ScriptableObject{
        [SerializeField] protected SOSingleVector2Int PlayerPosition;

        public abstract Vector2Int DefineTargetPosition();
    }
}