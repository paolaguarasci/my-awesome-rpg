using System;
using RPG.Combat;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control {
    public class PlayerController : MonoBehaviour {
        private Mover mover;
        private Fighter combat;
        private SpecialActions specialActions;

        private void Start () {
            mover = GetComponent<Mover> ();
            combat = GetComponent<Fighter> ();
            specialActions = GetComponent<SpecialActions> ();
        }
        private void Update () {
            InteractWithMovement ();
            InteractWithCombat ();
        }

        private void InteractWithCombat () {
            // Lista di HITs
            RaycastHit[] hits = Physics.RaycastAll (GetMouseRay ());
            foreach (RaycastHit hit in hits) {
                if (hit.transform.GetComponent<ReactiveTarget> ()) {
                    combat.Attack ();
                }
            }
        }

        private void InteractWithMovement () {
            if (Input.GetMouseButton (0)) {
                MoveToCursor ();
            }
        }

        public void MoveToCursor () {
            if (Physics.Raycast (GetMouseRay (), out RaycastHit hit)) {
                mover.MoveTo (hit.point);
            }
            Debug.DrawRay (GetMouseRay ().origin, GetMouseRay ().direction * 100);
        }

        private static Ray GetMouseRay () {
            return Camera.main.ScreenPointToRay (Input.mousePosition);
        }
    }
}