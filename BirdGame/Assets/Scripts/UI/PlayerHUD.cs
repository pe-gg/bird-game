using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerScoreText;
    private Player _player; 
    private float _timer;
    public int _score = 0;
 

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    void Start()
    {
        _playerScoreText.text = _score.ToString(); //start game with 0 score
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 1f)
        {
            _score += 1;

            //Update the HUD text when the score change
            _playerScoreText.text = _score.ToString();

            _timer = 0; //Reset timer to 0.
        }
        
    }
}
