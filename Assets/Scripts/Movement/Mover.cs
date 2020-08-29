﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Movement {

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
            UpdateAnimator ();
        }

        public void MoveToCursor () {
            lastRay = Camera.main.ScreenPointToRay (Input.mousePosition);
            if (Physics.Raycast (lastRay, out RaycastHit hit)) {
                MoveTo (hit.point);
            }
            Debug.DrawRay (lastRay.origin, lastRay.direction * 100);
        }

        public void MoveTo (Vector3 destination) {
            GetComponent<UnityEngine.AI.NavMeshAgent> ().destination = destination;
        }

        private void UpdateAnimator () {
            // InverseTransformDirection    direction   global  to local
            // TransformDirection           direction   local   to global
            Vector3 localVelocity = transform.InverseTransformDirection (agent.velocity);
            forwardSpeed = localVelocity.z;
            animator.SetFloat ("forwardSpeed", forwardSpeed);
        }

        public void setRange (float range) {
            agent.stoppingDistance = range;
            Debug.Log ("agent.stoppingDistance " + agent.stoppingDistance);
        }
    }
}