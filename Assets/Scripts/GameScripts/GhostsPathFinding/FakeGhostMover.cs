using UnityEngine;

namespace GameScripts.GhostsPathFinding{
    public class FakeGhostMover : MonoBehaviour{
        [SerializeField] private float _speed;
        private Transform _realGhostTransform;

        private void Awake() {
            _realGhostTransform = transform.parent.transform;
        }

        private void Update() {
            transform.position =
                Vector3.MoveTowards(transform.position, _realGhostTransform.position, Time.deltaTime * _speed);
        }
    }
}