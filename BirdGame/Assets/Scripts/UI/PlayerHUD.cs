using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerScoreText;
    private Player _player;
    private float _timer;
    private GameManager _gameManager;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
