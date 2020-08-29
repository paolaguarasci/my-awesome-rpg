using UnityEngine;

namespace RPG.Core {
    public class FollowCamera : MonoBehaviour {

        [SerializeField] private Player player;
        [SerializeField] private Vector3 distanceToPlayer;
        [SerializeField] private float angleToPlayer;

        private void Start () {
            distanceToPlayer = transform.position;
        }

        // Evita che la camera sia un po' "stick"
        private void LateUpdate () {
            transform.position = player.transform.position + distanceToPlayer;
        }
    }
}