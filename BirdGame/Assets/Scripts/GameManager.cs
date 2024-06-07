using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private String _scene;
    public Collectable[] collectables { get; private set; }
    
    private void Awake()
    {
        collectables = FindObjectsOfType<Collectable>();
        Debug.Log("collectables is " + collectables.Length);
    }
    
    #region Restart
    public void Restart()
    {
        SceneManager.LoadScene(_scene);
        Time.timeScale = 1.0f;
        

    }

    #endregion

    #region Note-Related Things

    //

    #endregion
}