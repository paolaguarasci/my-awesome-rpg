using UnityEngine;

public class Mover : MonoBehaviour {
    private UnityEngine.AI.NavMeshAgent agent;
    private Ray lastRay;
    private Animator animator;
    private float forwardSpeed;

    private void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        animator = GetComponent<Animator> ();
    }

    private void Update () {
        // Continuous click move    --->    GetMouseButton
        // OneShoot  click move     --->    GetMouseButtonDown
        if (Input.GetMouseButton (0)) {
            MoveToCursor ();
        }
        UpdateAnimator ();
    }

    private void MoveToCursor () {
        lastRay = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (lastRay, out RaycastHit hit)) {
            agent.destination = hit.point;
        }
        Debug.DrawRay (lastRay.origin, lastRay.direction * 100);
    }

    private void UpdateAnimator () {
        // InverseTransformDirection    direction   global  to local
        // TransformDirection           direction   local   to global
        Vector3 localVelocity = transform.InverseTransformDirection (agent.velocity);
        forwardSpeed = localVelocity.z;
        Debug.Log ("[MoveToCursor] forwardSpeed " + forwardSpeed);
        animator.SetFloat ("forwardSpeed", forwardSpeed);
    }
}