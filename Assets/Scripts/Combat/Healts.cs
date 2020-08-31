using System.Collections;
using UnityEngine;

namespace RPG.Combat {
  public class Healts : MonoBehaviour {
    [SerializeField] float healt = 100f;
    public bool isLive = true;
    public void TakeDamage (float damage) {
      healt -= damage;
      if (healt < 0) {
        healt = 0;
        isLive = false;
        StartCoroutine (Die ());
      }

      Debug.Log ("HEALT " + healt);
    }

    private IEnumerator Die () {
      this.gameObject.GetComponent<MeshRenderer> ().material.color = Color.red;
      yield return new WaitForSeconds (3);
      Destroy (this.gameObject);
    }
  }
}