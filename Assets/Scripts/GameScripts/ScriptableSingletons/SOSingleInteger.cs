using UnityEngine;

namespace GameScripts.ScriptableSingletons{
    [CreateAssetMenu(fileName = "IntegerSingleton", menuName = "Singletons/Integer")]
    public class SOSingleInteger : ScriptableObject{
        public int Value;
    }
}