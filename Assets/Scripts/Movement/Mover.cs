﻿using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement {

    public class Mover : MonoBehaviour, IAction {
        [SerializeField] Transform target;
        NavMeshAgent navMeshAgent;
        [SerializeField] private ActionScheduler scheduler;

        public void Start () {
            navMeshAgent = GetComponent<NavMeshAgent> ();
        }

        void Update () {
            UpdateAnimator ();
        }

        public void MoveToAction (Vector3 destination) {
            MoveTo (destination);
            scheduler.StartAction (this);
        }

        public void MoveTo (Vector3 destination) {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Cancel () {
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