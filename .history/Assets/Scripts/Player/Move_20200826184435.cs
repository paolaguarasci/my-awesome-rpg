using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    [SerializeField] private Transtorm positionTarget;
    private UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        agent.destination = positionTarget;
    }
}