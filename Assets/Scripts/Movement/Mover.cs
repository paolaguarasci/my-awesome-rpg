using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Combat;
using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement {

    public class Mover : MonoBehaviour  {
        [SerializeField] Transform target;
        NavMeshAgent navMeshAgent;
        [SerializeField] private ActionScheduler scheduler;

        private void Start () {
            navMeshAgent = GetComponent<NavMeshAgent> ();
        }

        void Update () {
            UpdateAnimator ();
        }

        public void MoveToAction (Vector3 destination) {
            GetComponent<Fighter> ().Cancel ();
            MoveTo (destination);
            scheduler.StartAction (this);
        }

        public void MoveTo (Vector3 destination) {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Stop () {
            // navMeshAgent.destination = null;
            navMeshAgent.isStopped = true;
        }

        private void UpdateAnimator () {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection (velocity);
            float speed = localVelocity.z;
            GetComponent<Animator> ().SetFloat ("forwardSpeed", speed);
        }
    }
}