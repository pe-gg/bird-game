using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private Inputs _gameInputs;


    public void OnEnable()
    {
        if (_gameInputs == null)
        {
            _gameInputs = new Inputs();

            _gameInputs.Locomotion.Up.performed += (val) =>
            {
                Debug.Log("UP");
            };
            _gameInputs.Locomotion.Up.canceled += (val) =>
            {
                Debug.Log("IDLE");
            };
            _gameInputs.Locomotion.Down.performed += (val) =>
            {
                Debug.Log("DOWN");
            };
            _gameInputs.Locomotion.Down.canceled += (val) =>
            {
                Debug.Log("IDLE");
            };
        }

        _gameInputs.Locomotion.Enable();
    }
}
