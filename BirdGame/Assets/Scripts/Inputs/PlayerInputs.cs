using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    private Inputs _gameInputs;
    private PlayerStateMachine _playerStateMachine;

    private void Awake()
    {
        _playerStateMachine = GetComponent<PlayerStateMachine>();
    }

    public void OnEnable()
    {
        if (_gameInputs == null)
        {
            _gameInputs = new Inputs();

            _gameInputs.Locomotion.Up.performed += (val) =>
            {
                _playerStateMachine.SetState(_playerStateMachine.glideState);
            };
            _gameInputs.Locomotion.Up.canceled += (val) =>
            {
                _playerStateMachine.SetState(_playerStateMachine.idleState);
            };
            _gameInputs.Locomotion.Down.performed += (val) =>
            {
                _playerStateMachine.SetState(_playerStateMachine.fallState);
            };
            _gameInputs.Locomotion.Down.canceled += (val) =>
            {
                _playerStateMachine.SetState(_playerStateMachine.idleState);
            };
            _gameInputs.Locomotion.UpDraft.performed += (val) =>
            {
                _playerStateMachine.SetState(_playerStateMachine.upState);
            };
            _gameInputs.Locomotion.UpDraft.canceled += (val) =>
            {
                _playerStateMachine.SetState(_playerStateMachine.fallState);
            };
        }

        _gameInputs.Locomotion.Enable();
    }
}
