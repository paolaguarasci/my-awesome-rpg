using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
public class Move : MonoBehaviour {

    [SerializeField] private Transform positionTarget;
    private UnityEngine.AI.NavMeshAgent agent;
    void Start () {

    }
    void Update () {
        agent.destination = positionTarget;
    }
}