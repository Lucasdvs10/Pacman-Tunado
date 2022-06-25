using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.StateMachine.StateDeciders{
    [CreateAssetMenu(fileName = "FarFromPlayerDecider", menuName = "StateMachine/Deciders/FarFromPlayer", order = 0)]
    public class SOFarFromPlayerDecider : SOBaseStateDecider{
        [SerializeField] private SOSingleVector2Int _playerPositionSingleton;
        [SerializeField] private SOSingleVector2Int _ghostPositionSingleton;
        [SerializeField] private int _manhatamDistance;


        public override bool Decide(StateMachine stateMachine) {
            var distance = Mathf.Abs(_playerPositionSingleton.Value.x - _ghostPositionSingleton.Value.x) +
                           Mathf.Abs(_playerPositionSingleton.Value.y - _ghostPositionSingleton.Value.y);

            return distance > _manhatamDistance;
        }
    }
}