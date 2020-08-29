using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat {

    public class Fighter : MonoBehaviour {
        [SerializeField] float weaponRange = 2f;
        Transform target;
        [SerializeField] private ActionScheduler scheduler;
        private void Update () {

            if (target == null) return;

            float distanceToTarget = Vector3.Distance (transform.position, target.position);

            Debug.Log ("[FIGHTER] Distanza dal target: " + distanceToTarget);

            if (!(distanceToTarget < weaponRange)) {
                GetComponent<Mover> ().MoveTo (target.position);
            } else {
                GetComponent<Mover> ().Stop ();
            }
        }

        public void Attack (ReactiveTarget combatTarget) {
            target = combatTarget.transform;
            scheduler.StartAction (this);
        }

        public void Cancel () {
            target = null;
        }

    }
}