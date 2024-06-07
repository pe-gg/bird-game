using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerScoreText;
    private float _timer;
    private GameManager _gameManager;
    public int _score = 0;

    void Start()
    {
        _playerScoreText.text = _score.ToString(); //start game with 0 score
    }

    void Update()
    {
        _playerScoreText.text = _score.ToString();
    }
}
