using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeEntityController : MonoBehaviour {
    
    public UnityEvent OnEntityDied;

    private bool _isAlive;

    private void Start() {
        _isAlive = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (_isAlive && other.CompareTag("Explosion"))
            KillEntity();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (transform.CompareTag("Enemy"))
            return;
        
        if (_isAlive && other.collider.CompareTag("Enemy"))
            KillEntity();
    }
    

    private void KillEntity() {
        _isAlive = false;
        OnEntityDied.Invoke();
        Destroy(gameObject);
    }
}
