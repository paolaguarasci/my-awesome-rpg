using System.Collections;
using System.Collections.Generic;
using Unity.AI;
using UnityEngine;
public class Move : MonoBehaviour {

    [SerializeField] private Transform positionTarget;
    private UnityEngine.AI.NavMeshAgent agent;
    void Start () {

    }
    void Update () {
        agent.destination = positionTarget;
    }
}