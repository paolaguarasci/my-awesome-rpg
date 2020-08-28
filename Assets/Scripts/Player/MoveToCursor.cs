using UnityEngine;

public class MoveToCursor : MonoBehaviour {
    [SerializeField] private Transform positionTarget;
    private UnityEngine.AI.NavMeshAgent agent;
    private Ray lastRay;
    private Animator animator;
    private float forwardSpeed;

    private void Start() {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            MoveTo();
        }
        forwardSpeed = Mathf.Clamp(Mathf.Abs(agent.velocity.z), 0.0f, 1.0f);
        Debug.Log("[MoveToCursor] forwardSpeed " + forwardSpeed);
        animator.SetFloat("forwardSpeed", forwardSpeed);
    }

    private void MoveTo() {
        lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(lastRay, out RaycastHit hit)) {
            agent.destination = hit.point;
        }
        Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
    }
}