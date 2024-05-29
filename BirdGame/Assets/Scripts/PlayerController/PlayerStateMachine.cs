using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private IState _currentState;

    public PlayerIdleState idleState;
    public PlayerMoveUpState moveUpState;
    public PlayerMoveDownState moveDownState;

    public void SetState(IState newState)
    {
        _currentState?.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }

    private void Awake()
    {
        idleState = new PlayerIdleState(this);
        moveUpState = new PlayerMoveUpState(this);
        moveDownState = new PlayerMoveDownState(this);

        //Set player default state
        SetState(idleState);
    }

    private void Update()
    {
        _currentState?.UpdateState();
    }
}
