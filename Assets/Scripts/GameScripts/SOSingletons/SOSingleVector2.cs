using UnityEngine;

namespace GameScripts.SOSingletons{
    [CreateAssetMenu(fileName = "SingleVector2", menuName = "Singletons/Vector2", order = 0)]
    public class SOSingleVector2 : ScriptableObject{
        public Vector2 Value;
    }
}