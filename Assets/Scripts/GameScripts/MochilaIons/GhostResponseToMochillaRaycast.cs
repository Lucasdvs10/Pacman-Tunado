using UnityEngine;

namespace GameScripts.MochilaIons{
    public class GhostResponseToMochillaRaycast : MonoBehaviour, IMochilaRaycastDetectable{
        public void RespondToRaycastDetection() {
            print("Oh não, o raycast pegou em mim :(");
        }
    }
}