using System;
using UnityEngine;

namespace GameScripts{
    public class Effector : MonoBehaviour{
        private Rigidbody2D rgbTarget;
        private void OnTriggerStay2D(Collider2D other) {
            if(other.tag == "Fantasma"){
                
                if(rgbTarget == null) {
                    rgbTarget = other.GetComponent<Rigidbody2D>();
                }
                var dir = (transform.position - other.transform.position).normalized;

                rgbTarget.AddForce(dir * 15, ForceMode2D.Force);
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            if (other.attachedRigidbody == rgbTarget) {
                rgbTarget = null;
            }
        }
    }
}