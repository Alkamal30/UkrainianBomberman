using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bomb : MonoBehaviour {

    public UnityAction<Vector3> OnBombExplodedAction;


    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }

    private void OnDestroy() {
        OnBombExplodedAction.Invoke(transform.position);
    }
}
