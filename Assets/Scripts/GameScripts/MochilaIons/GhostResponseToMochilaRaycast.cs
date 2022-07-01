using GameScripts.GameEvent;

namespace GameScripts.MochilaIons{
    public class GhostResponseToMochilaRaycast : BaseEventEmmiter, IMochilaRaycastDetectable{
        public void RespondToRaycastDetection() {
            InvokeEvent();
        }
    }
}