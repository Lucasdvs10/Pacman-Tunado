using UnityEngine;

namespace GameScripts.ScriptableSingletons{
    [CreateAssetMenu(fileName = "Vector2Singleton", menuName = "VectorSingleton")]
    public class SOVector2Singleton : ScriptableObject{
        public Vector2 Value;
    }
}