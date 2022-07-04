using GameScripts.GameEvent;
using UnityEngine;

namespace GameScripts.MochilaIons{
    [RequireComponent(typeof(CircleCollider2D))]
    public class GhostResponseToMochilaRaycast : BaseEventEmmiter, IMochilaRaycastDetectable{
        public void RespondToRaycastDetection() {
            InvokeEvent();
        }
    }
}