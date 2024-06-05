using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverMenuUI;
    [SerializeField]
    string LoadScene; //scene name

    private GameManager _gameManager;

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

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
}
