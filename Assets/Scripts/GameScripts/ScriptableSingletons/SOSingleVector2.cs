using UnityEngine;

namespace GameScripts.ScriptableSingletons{
    [CreateAssetMenu(fileName = "SingletonVector2", menuName = "Singletons/Vector")]
    public class SOSingleVector2 : ScriptableObject{
        public Vector2 Value;
    }
}