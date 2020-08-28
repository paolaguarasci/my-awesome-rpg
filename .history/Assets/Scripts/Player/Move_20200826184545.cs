using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
public class Move : MonoBehaviour {

    [SerializeField] private Transform positionTarget;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        agent.destination = positionTarget;

    }
}