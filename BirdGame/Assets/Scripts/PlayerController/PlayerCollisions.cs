using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private float _boostForce = 2f;
    [SerializeField] private float _obstacleHitForce = 10f;
    [SerializeField] AudioManager audioManager;
    private BoxCollider _col;
    private Rigidbody _rb;
    private GameManager _gameManager;
    private GlidingSystem _gliding;
    
    private void Awake()
    {
        _gliding = GetComponent<GlidingSystem>();
        _col = GetComponent<BoxCollider>();
        _rb = GetComponent<Rigidbody>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoostObject")) //you should definitely use an interface for this, but we don't have too many collisions so just keeping it simple.
        {
            Debug.Log("Boost!");
            BoostObject bo = other.gameObject.GetComponent<BoostObject>();
            //_rb.velocity = new Vector3(_rb.velocity.x, 0, 0); //set the player's y velocity to 0 so that any downwards force does not interfere

            audioManager.Play("Wind");

            if (bo.thrustUpwards)
                
            {
                _rb.velocity = Vector3.up *_boostForce;
                _rb.angularVelocity = Vector3.right *_boostForce;
            }

            else if(bo.thrustFowards)
            {
                _gliding.maxSpeed = 50.0f;
               _rb.velocity = Vector3.right *_boostForce;
               Invoke("MaxSpeed", 2.0f);
            }

            else if (!bo.thrustUpwards)
            {
                _rb.velocity = Vector3.down *_boostForce;
                _rb.angularVelocity = Vector3.right *_boostForce;
            }
            
            
            
        }

        if (other.CompareTag("Obstacle"))
        {
            audioManager.Play("Uncrumpling");

            Debug.Log("Obstacle hit");
            _rb.velocity = new Vector3(-_obstacleHitForce, -(_obstacleHitForce / 3), 0);
        }

        if (other.CompareTag("Pickup"))
        {
            audioManager.Play("Crumpling");

            Debug.Log("Pickup collected");
            Collectable pickup = other.gameObject.GetComponent<Collectable>();
            pickup.collected = true;
            other.gameObject.SetActive(false);
            
        }
        
        
        
        
    }

    private void MaxSpeed()
    {
        _gliding.maxSpeed = 25.0f;
    }
}
