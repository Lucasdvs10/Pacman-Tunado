using UnityEngine;

namespace GameScripts{
    public class FakePlayerMover : MonoBehaviour{
        [SerializeField] private float _movementSpeed;
        
        private Transform _realPlayerTransform;

        private void Awake() {
            _realPlayerTransform = transform.parent.transform;
        }

        private void Start() {
            transform.parent = null;
        }

        private void Update() {
            transform.position = Vector2.MoveTowards(transform.position, _realPlayerTransform.position,
                Time.deltaTime * _movementSpeed);
        }

    }
}