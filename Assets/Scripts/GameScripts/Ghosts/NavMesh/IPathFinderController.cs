using UnityEngine;

namespace GameScripts.Ghosts.NavMesh{
    public interface IPathFinderController{
        void SetPositionDestination(Vector2 destination);
        void SetGameObjToFollow(GameObject gameObject);
    }
}