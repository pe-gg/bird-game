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

    [SerializeField] private float deathPointLow;
    [SerializeField] private float deathPointHigh;

    [SerializeField] private float _time;

    private void Awake()
    {
        
        _gameManager = FindObjectOfType<GameManager>();
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        Invoke("Grav", _time);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            _gameOverMenu.HandleGameOver();
            Debug.Log("gameover");
            
        }
    }

    private void FixedUpdate()
    {
        if (this.transform.position.y <= deathPointLow || this.transform.position.y >= deathPointHigh )
        {
            _gameOverMenu.HandleGameOver();
            Debug.Log("gameover");
        }
    }

    private void Grav()
    {
        _rb.useGravity = true;
    }
}
