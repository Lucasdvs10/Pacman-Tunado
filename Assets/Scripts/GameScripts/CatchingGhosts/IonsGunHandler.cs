using System.Collections;
using GameScripts.ScriptableSingletons;
using UnityEngine;

namespace GameScripts{
    public class IonsGunHandler : MonoBehaviour{
        [SerializeField] private SOSingleInteger _batteryLevel;
        [SerializeField] private GameObject _forceEffector;

        private bool gunActivated;
        
        public void StartActivateGunCoroutine() {
            if (_batteryLevel.Value <= 0) return;

            StartCoroutine(ActivateGunCoroutine());
        }

        private IEnumerator ActivateGunCoroutine() {
            _forceEffector.SetActive(true);
            yield return new WaitForSeconds(4f);
            _batteryLevel.Value--;
            _forceEffector.SetActive(false);
        }


    }
}