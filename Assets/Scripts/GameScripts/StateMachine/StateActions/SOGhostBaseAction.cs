using GameScripts.GhostsPathFinding;
using GameScripts.GhostsPathFinding.SOTargetDefiners;
using UnityEngine;

namespace GameScripts.StateMachine.StateActions{
    public abstract class SOGhostBaseAction : SOBaseStateAction{
        [SerializeField] protected SOBaseTargetDefiner targetDefiner;

        protected virtual void SetTargetDefiner(StateMachine stateMachine) {
            var targetDefinerController = stateMachine.gameObject.GetComponent<TargetDefinerController>();
            targetDefinerController.SetTargetDefiner(targetDefiner);
        }
    }
}