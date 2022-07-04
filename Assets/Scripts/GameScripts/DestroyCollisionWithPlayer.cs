using UnityEngine;

namespace GameScripts{
    [RequireComponent(typeof(Collider2D))]
    public class DestroyCollisionWithPlayer : MonoBehaviour{

        private void OnTriggerEnter2D(Collider2D col) {
            if(col.tag == "Player")
                DestroyThisObject();
        }

        public void DestroyThisObject() {
            Destroy(gameObject);
        }
        
    }
}