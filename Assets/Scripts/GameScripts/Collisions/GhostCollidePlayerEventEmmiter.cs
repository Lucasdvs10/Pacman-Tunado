using GameScripts.GameEvent;
using GameScripts.GhostsPathFinding;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.Collisions{
    public class GhostCollidePlayerEventEmmiter : BaseEventEmmiter{
        [SerializeField] private SOGameEvent[] _stateEventEnterToListen;
        [SerializeField] private SOGameEvent[] _stateEventExitToListen;
        [SerializeField] private SOSingleVector2Int _playerPosition;
        [SerializeField] private SOGameEvent _eventToListen;
        private PathFindingMoverBehaviour _pathFindingMoverBehaviour;
        private bool _flag;


        private void Awake() {
            _pathFindingMoverBehaviour = GetComponent<PathFindingMoverBehaviour>();
        }

        private void OnEnable() {
            _eventToListen.Subscribe(CheckIfCollidedWithPlayer);
            
            
            foreach (var state in _stateEventEnterToListen) {
                state.Subscribe(TurnOnFlag);
            }
            
            foreach (var state in _stateEventExitToListen) {
                state.Subscribe(TurnOffFlag);
            }
        }

        private void OnDisable() {
            _eventToListen.Unsubscribe(CheckIfCollidedWithPlayer);
            
            foreach (var state in _stateEventEnterToListen) {
                state.Unsubscribe(TurnOnFlag);
            }
            
            foreach (var state in _stateEventExitToListen) {
                state.Unsubscribe(TurnOffFlag);
            }
        }

        private void TurnOnFlag() => _flag = true;
        private void TurnOffFlag() => _flag = false;


        private void CheckIfCollidedWithPlayer() {
            if(_flag && _playerPosition.Value == _pathFindingMoverBehaviour.GridPosition)
                InvokeEvent();
        }
        
        
    }
}