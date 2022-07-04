using UnityEngine;

namespace GameScripts.SOSingletons{
    [CreateAssetMenu(fileName = "IntSingleton", menuName = "Singletons/Integer")]
    public class SOSingleInt : ScriptableObject{
        public int Value;
    }
}