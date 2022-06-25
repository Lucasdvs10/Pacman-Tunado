using UnityEngine;

namespace GameScripts.StateMachine.StateActions.GhostsActions{
    [CreateAssetMenu(fileName = "AttackAction", menuName = "StateMachine/Actions/Ghosts")]
    public class SOAttackAction : SOGhostBaseAction{
        public override void ExecuteAction(StateMachine stateMachine) {
            SetTargetDefiner(stateMachine);
        }
    }
}