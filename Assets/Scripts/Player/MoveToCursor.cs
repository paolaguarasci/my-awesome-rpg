using UnityEngine;

public class MoveToCursor : MonoBehaviour {
    [SerializeField] private Transform positionTarget;
    private UnityEngine.AI.NavMeshAgent agent;
    private Ray lastRay;

    private void Start() {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            MoveTo();
        }
    }

    private void MoveTo() {
        lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(lastRay, out RaycastHit hit)) {
            agent.destination = hit.point;
        }
        Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
    }
}