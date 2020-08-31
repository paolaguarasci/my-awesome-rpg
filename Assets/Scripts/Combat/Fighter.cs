using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Combat {

    public class Fighter : MonoBehaviour, IAction {
        [SerializeField] private ActionScheduler scheduler;
        [SerializeField] float weaponRange = 1f;
        [SerializeField] float timeBetweenAttacks = 5f;
        Transform target;

        float timeSinceLastAttack = 0;

        private void Update () {
            timeSinceLastAttack += Time.deltaTime;

            if (target == null) return;
            float distanceToTarget = Vector3.Distance (transform.position, target.position);
            if (!(distanceToTarget < weaponRange)) {
                GetComponent<Mover> ().MoveTo (target.position);
            } else {
                GetComponent<Mover> ().Cancel ();
                AttackBehaviour ();
            }
        }

        private void AttackBehaviour () {
            Debug.Log ("Time dall'ultimo attacco " + timeSinceLastAttack);
            Debug.Log ("Time tra attacchi " + timeBetweenAttacks);
            if (timeSinceLastAttack >= timeBetweenAttacks) {
                transform.LookAt (target);
                // if (Input.GetMouseButton (0)) {
                    GetComponent<Animator> ().SetTrigger ("attack");
                //}
                timeSinceLastAttack = 0;
            }
        }

        public void Attack (ReactiveTarget combatTarget) {
            target = combatTarget.transform;
            scheduler.StartAction (this);
        }

        public void Cancel () {
            GetComponent<Animator> ().ResetTrigger ("attack");
            target = null;
        }

        public void Start () {
            // throw new System.NotImplementedException ();
        }

        // Animation Event
        public void Hit () {
            Debug.Log ("Hit!");
        }
    }
}