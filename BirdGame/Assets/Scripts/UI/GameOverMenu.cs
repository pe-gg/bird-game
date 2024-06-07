using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverMenuUI;
    [SerializeField]
    string LoadScene; //scene name

    private GameManager _gameManager;

    private Image[] _papers;
    private GameObject _paperParent;

   
    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _paperParent = GameObject.Find("GraftedPaper");
        _papers = _paperParent.GetComponentsInChildren<Image>(includeInactive: true);
        //Debug.Log("papers is " + _papers.Length);
        SetPaperVisibility();
    }

    private void SetPaperVisibility()
    {
        for (int i = 0; i < _gameManager.collectables.Length; i++) //increment through array of collectables
        {
            if (_gameManager.collectables[i].collected) //if the collectable at the current array was collected,
            {
                _papers[Math.Clamp(i,0,_papers.Length)].gameObject.SetActive(true);//set the corresponding paper to be set as active
            }
        }
    }
    
    
    //set game time back to normal and load restartScene
    public void RestartGame()
    {
        _gameManager.Restart();
    }
    public void HandleGameOver()
    {
        //pause time/game
        Time.timeScale = 0f;

        //enables the cursor and turns it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameOverMenuUI.SetActive(true);
    }
}
