using UnityEngine;

public class FollowCamera : MonoBehaviour {

    [SerializeField] private Player player;
    [SerializeField] private Vector3 distanceToPlayer;
    [SerializeField] private float angleToPlayer;

    private void Start() {
        distanceToPlayer = transform.position;
    }


    private void Update() {
        transform.position = player.transform.position + distanceToPlayer;
    }
}
