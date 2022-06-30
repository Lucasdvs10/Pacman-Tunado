using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.StateMachine.StateDeciders{
    [CreateAssetMenu(fileName = "IsAtPosition", menuName = "StateMachine/Deciders/IsAtPosition")]
    public class SOIsAtPositionDecider : SOBaseStateDecider{
        [SerializeField] private SOSingleVector2Int _currentPosition;
        [SerializeField] private SOSingleVector2Int _targetPosition;
        public override bool Decide(StateMachine stateMachine) {
            return _currentPosition.Value == _targetPosition.Value;
        }
    }
}