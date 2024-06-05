using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private float _boostForce = 2f;
    [SerializeField] private float _obstacleHitForce = 10f;
    private BoxCollider _col;
    private Rigidbody _rb;
    
    private void Awake()
    {
        _col = GetComponent<BoxCollider>();
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoostObject")) //you should definitely use an interface for this, but we don't have too many collisions so just keeping it simple.
        {
            Debug.Log("Boost!");
            BoostObject bo = other.gameObject.GetComponent<BoostObject>();
            //_rb.velocity = new Vector3(_rb.velocity.x, 0, 0); //set the player's y velocity to 0 so that any downwards force does not interfere
            if (bo.thrustUpwards)
                _rb.AddForce(Vector3.up * _boostForce, ForceMode.Impulse);
            else
                _rb.AddForce(Vector3.down * _boostForce, ForceMode.Impulse);
        }

        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle hit");
            _rb.velocity = new Vector3(-_obstacleHitForce, -(_obstacleHitForce / 3), 0);
        }

        if (other.CompareTag("Pickup"))
        {
            Debug.Log("Pickup collected");
            Destroy(other.gameObject);
        }
    }
}
