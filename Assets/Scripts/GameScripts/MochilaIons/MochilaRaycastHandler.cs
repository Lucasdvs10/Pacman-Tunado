using GameScripts.GameEvent;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.MochilaIons{
    [RequireComponent(typeof(RaycastEmmiter), typeof(BatteryController))]
    public class MochilaRaycastHandler : MonoBehaviour{
        [SerializeField] private SOGameEvent _event;
        [SerializeField] private SOSingleInt _batteryAmountSingleton;
        [SerializeField] private int _costToActivateGun;
        private RaycastEmmiter _raycastEmmiter;
        private BatteryController _batteryController;

        private void Awake() {
            _raycastEmmiter = GetComponent<RaycastEmmiter>();
        }

        private void OnEnable() {
            _event.Subscribe(EmitRaycastAndActivateResponse);
        }

        private void OnDisable() {
            _event.Unsubscribe(EmitRaycastAndActivateResponse);
        }


        [ContextMenu("Emitir raycast com resposta")]
        private void EmitRaycastAndActivateResponse() {
            if (_batteryAmountSingleton.Value < _costToActivateGun) return;

            _batteryController.AddBatteryAmount(-_costToActivateGun);
            
            var hit = _raycastEmmiter.EmitRayCast();
            var otherTransform = hit.transform;

            if (otherTransform == null) return;

            var otherMochilaDetectable = otherTransform.GetComponent<IMochilaRaycastDetectable>();
            
            otherMochilaDetectable?.RespondToRaycastDetection();
        }
        
    }
}