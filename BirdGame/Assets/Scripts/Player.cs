using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private PlayerHUD _playerHUD;

    [SerializeField]
    private GameOverMenu _gameOverMenu;
    
    private GameManager _gameManager;
    private Rigidbody _rb;
    private Animator _animator;

    [SerializeField] private float deathPointLow;
    [SerializeField] private float deathPointHigh;

    [SerializeField] private float _GravityGracePeriod;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _gameManager = FindObjectOfType<GameManager>();
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        Invoke("Grav", _GravityGracePeriod);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("damagingObstacle"))
        {
            _animator.enabled = true;
            _animator.Play("PlaneCrumple");
            _rb.velocity = Vector3.down *100f;
            _rb.mass = 1000;
            Debug.Log("gameOver");
            Invoke("Die", 2.0f);
        }
    }

    private void FixedUpdate()
    {
        if (this.transform.position.y <= deathPointLow || this.transform.position.y >= deathPointHigh )
        {
            _animator.enabled = true;
            _animator.Play("PlaneCrumple");
            _rb.velocity = Vector3.down *100f;
            _rb.mass = 1000;
            Invoke("Die", 2.0f);
            Debug.Log("gameover");
        }
    }

    private void Grav()
    {
        _rb.useGravity = true;
    }

    private void Die()
    {
        _gameOverMenu.HandleGameOver();
    }
}
