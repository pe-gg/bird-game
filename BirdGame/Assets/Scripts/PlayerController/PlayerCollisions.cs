using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private float _boostForce = 2f;
    private BoxCollider _col;
    private Rigidbody _rb;
    
    private void Awake()
    {
        _col = GetComponent<BoxCollider>();
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoostObject"))
        {
            Debug.Log("Boost!");
            _rb.velocity = new Vector3(_rb.velocity.x, 0, 0); //set the player's y velocity to 0 so that any downwards force does not interfere
            _rb.AddForce(Vector3.up * _boostForce, ForceMode.Impulse);
        }
    }
}
