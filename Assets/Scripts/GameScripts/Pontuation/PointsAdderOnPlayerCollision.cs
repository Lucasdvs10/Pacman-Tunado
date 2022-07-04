using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.Pontuation{
    [RequireComponent(typeof(Collider2D))]
    public class PointsAdderOnPlayerCollision : MonoBehaviour{
        [SerializeField] private SOSingleInt _pointsSingleton;
        [SerializeField] private int _pointsAmountValue;
        
        private void Start() {
            _pointsSingleton.Value = 0;
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if(col.tag == "Player")
                AddAmount();
        }

        public void AddAmount() {
            _pointsSingleton.Value += _pointsAmountValue;
        }
        
    }
}