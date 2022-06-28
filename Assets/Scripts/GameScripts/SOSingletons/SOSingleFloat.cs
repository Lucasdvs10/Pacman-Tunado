using UnityEngine;

namespace GameScripts.SOSingletons{
    [CreateAssetMenu(fileName = "SingleFloat", menuName = "Singletons/Float")]
    public class SOSingleFloat : ScriptableObject{
        public float Value;
    }
}