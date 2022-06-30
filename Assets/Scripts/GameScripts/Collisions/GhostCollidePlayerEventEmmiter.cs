using GameScripts.GameEvent;
using UnityEngine;

namespace GameScripts.Collisions{
    [RequireComponent(typeof(CircleCollider2D))]
    public class GhostCollidePlayerEventEmmiter : BaseEventEmmiter{
        private void OnTriggerEnter2D(Collider2D col) {
            if(col.tag == "Player")
                InvokeEvent();
        }
    }
}