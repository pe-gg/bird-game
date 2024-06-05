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

    [SerializeField] private float deathPointLow;
    [SerializeField] private float deathPointHigh;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
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
}
