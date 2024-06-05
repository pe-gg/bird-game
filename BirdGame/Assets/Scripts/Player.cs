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
}
