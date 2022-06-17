using UnityEngine;

namespace GameScripts{
    public class FakePlayerMover : MonoBehaviour{
        [SerializeField] private float _movementSpeed;
        
        private Transform _realPlayerTransform;
        private GameObject _realPlayerGameObj;

        private void Awake() {
            _realPlayerTransform = transform.parent.transform;
            _realPlayerGameObj = _realPlayerTransform.gameObject;
        }

        private void Start() {
            transform.parent = null;
        }

        private void Update() {
            transform.position = Vector2.MoveTowards(transform.position, _realPlayerTransform.position,
                Time.deltaTime * _movementSpeed);
        }

        public GameObject RealPlayerGameObj => _realPlayerGameObj;
    }
}