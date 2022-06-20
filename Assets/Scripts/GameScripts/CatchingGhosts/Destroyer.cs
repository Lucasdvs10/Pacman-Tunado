using UnityEngine;

namespace GameScripts{
    public class Destroyer : MonoBehaviour{
        private void OnTriggerEnter2D(Collider2D other) {
            if(other.tag == "Fantasma")
                Destroy(other.gameObject);
        }
    }
}