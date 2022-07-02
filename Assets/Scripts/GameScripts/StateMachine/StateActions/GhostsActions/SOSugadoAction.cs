using System.Collections;
using GameScripts.GhostsPathFinding;
using GameScripts.SOSingletons;
using UnityEngine;

namespace GameScripts.StateMachine.StateActions.GhostsActions{
    [CreateAssetMenu(fileName = "Sugado", menuName = "StateMachine/Actions/Ghosts/Sugado")]
    public class SOSugadoAction : SOGhostBaseAction{
        [SerializeField] private SOSingleVector2 _direction;
        public override void ExecuteAction(StateMachine stateMachine) {
        }

        public override void OnActionEnter(StateMachine stateMachine) {
            var pathFinderBehaviour = stateMachine.GetComponent<PathFindingMoverBehaviour>();

            SetTargetDefiner(stateMachine);
            pathFinderBehaviour.StopMoveToTargetCoroutine();
            stateMachine.StartCoroutine(WalkToDirectionCoroutine(stateMachine, pathFinderBehaviour));
        }

        public override void OnActionExit(StateMachine stateMachine) {
            var pathFinderBehaviour = stateMachine.GetComponent<PathFindingMoverBehaviour>();
            stateMachine.StopAllCoroutines();
            pathFinderBehaviour.StartMoveToTargetCoroutine();
        }

        private IEnumerator WalkToDirectionCoroutine(StateMachine stateMachine, PathFindingMoverBehaviour pathFinderBehaviour) {
            while(true){
                yield return new WaitForSeconds(0.5f);
                var direction = new Vector2Int((int) -_direction.Value.y, (int) _direction.Value.x);
                pathFinderBehaviour.Move(-direction);
            }
            
        }
    }
}