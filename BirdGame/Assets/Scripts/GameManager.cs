using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private String _scene;
    
    #region Restart
    public void Restart()
    {
        SceneManager.LoadScene(_scene);
        Time.timeScale = 1.0f;
        

    }

    private void Awake()
    {
        
    }

    #endregion
}