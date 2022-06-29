using UnityEngine;

namespace GameScripts.StateMachine.StateDeciders{
    [CreateAssetMenu(fileName = "AlwaysTrue", menuName = "StateMachine/Deciders/Always True", order = 0)]
    public class SOAlwaysTrueDecider : SOBaseStateDecider{
        public override bool Decide(StateMachine stateMachine) {
            return true;
        }
    }
}