using UnityEngine;

public class PlayerIdleState : IState
{
    private PlayerStateMachine _stateMachine;

    //PlayerIdleState constructor
    public PlayerIdleState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void EnterState()
    {
        Debug.Log("EnterState IDLE");
    }

    public void ExitState()
    {
        Debug.Log("ExitState IDLE");
    }

    public void UpdateState()
    {
        Move();
        Debug.Log("UpdateState IDLE");
    }

    private void Move()
    {
        _stateMachine.rb.AddForce(Vector3.right * _stateMachine.speed);
    }
}
