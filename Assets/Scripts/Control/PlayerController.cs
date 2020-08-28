using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Mover mover;
    private Combat combat;
    private SpecialActions specialActions;

    private Ray lastRay;

    private void Start () {
        mover = GetComponent<Mover> ();
        combat = GetComponent<Combat> ();
        specialActions = GetComponent<SpecialActions> ();
    }

    private void Update () {
        if (Input.GetMouseButton (0)) {
            MoveToCursor();
        }
    }

    public void MoveToCursor () {
        lastRay = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (lastRay, out RaycastHit hit)) {
            mover.MoveTo (hit.point);
        }
        Debug.DrawRay (lastRay.origin, lastRay.direction * 100);
    }
}