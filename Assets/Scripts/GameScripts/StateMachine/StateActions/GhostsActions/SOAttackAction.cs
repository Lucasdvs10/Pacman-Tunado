using UnityEngine;

namespace GameScripts.StateMachine.StateActions.GhostsActions{
    [CreateAssetMenu(fileName = "ActionChangeTargetDefiner", menuName = "StateMachine/Actions/Ghosts/ChangeTargetDefiner")]
    public class SOAttackAction : SOGhostBaseAction{
        public override void ExecuteAction(StateMachine stateMachine) {
            SetTargetDefiner(stateMachine);
        }
    }
}