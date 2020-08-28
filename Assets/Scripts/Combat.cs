using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {
    private Animator animator;
    private Mover mover;
    [SerializeField] private float rangeToEnemy = 1f;

    private void Start () {
        animator = GetComponent<Animator> ();
        mover = GetComponent<Mover> ();
    }

    void Update () {
        Vector3 fwd = transform.TransformDirection (Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast (transform.position, fwd, out hit, 1f)) {
            if (hit.transform.GetComponent<ReactiveTarget> ()) {
                mover.setRange (rangeToEnemy);
                Debug.Log ("[Attck] Attacco un nemico!");
            } else {
                mover.setRange (0);
            }
        }
    }
}