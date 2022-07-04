using System;
using GameScripts.GameEvent;
using UnityEngine;

namespace GameScripts.Collisions{
    [RequireComponent(typeof(Collider2D))]
    public class CollisionPlayerEventEmitter : BaseEventEmmiter{
        private void OnTriggerEnter2D(Collider2D col) {
            if(col.tag == "Player")
                InvokeEvent();
        }
    }
}