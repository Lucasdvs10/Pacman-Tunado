using UnityEngine;

namespace GameScripts.SOSingletons{
    [CreateAssetMenu(fileName = "SingleVector", menuName = "Singletons/Vector2Int")]
    public class SOSingleVector2Int : ScriptableObject{
        public Vector2Int Value;
    }
}