using GameScripts.GhostsPathFinding;
using GameScripts.GhostsPathFinding.SOTargetDefiners;
using UnityEngine;

namespace GameScripts.StateMachine.StateActions{
    public abstract class SOGhostBaseAction : SOBaseStateAction{
        [SerializeField] protected SOBaseTargertDefiner _targertDefiner;

        protected virtual void SetTargetDefiner(StateMachine stateMachine) {
            var targetDefinerController = stateMachine.gameObject.GetComponent<TargetDefinerController>();
            targetDefinerController.SetTargetDefiner(_targertDefiner);
        }
    }
}