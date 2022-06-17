using UnityEngine;

namespace GameScripts{
    public class FakePlayerPositionManager : MonoBehaviour{
        [SerializeField] private float _movementSpeed;
        private Transform _realPlayerTransform;
        private Vector2 _fakePlayerPosition;
        private Vector2 _realPlayerPosition;
        private bool _isInRealPosition;

        private void Awake() {
            _realPlayerTransform = transform.parent.transform;
            _fakePlayerPosition = transform.position;
        }

        private void Start() {
            transform.parent = null;
        }

        private void Update() {
            _fakePlayerPosition = transform.position;
            if (Vector2.Distance(_fakePlayerPosition, _realPlayerPosition) == 0) {
                _isInRealPosition = true;
            }
            else {
                _isInRealPosition = false;
            }
            _realPlayerPosition = _realPlayerTransform.position;
            transform.position = Vector2.MoveTowards(transform.position, _realPlayerPosition,
                    Time.deltaTime * _movementSpeed);
        }

        public bool IsInRealPosition => _isInRealPosition;
    }
}