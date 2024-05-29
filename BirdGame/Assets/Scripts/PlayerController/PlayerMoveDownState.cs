using UnityEngine;

public class PlayerMoveDownState : IState
{
    private PlayerStateMachine _stateMachine;

    //PlayerMoveDownState constructor
    public PlayerMoveDownState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void EnterState()
    {
        Debug.Log("EnterState DOWN");
    }

    public void ExitState()
    {
        Debug.Log("ExitState DOWN");
    }

    public void UpdateState()
    {
        Debug.Log("UpdateState DOWN");
    }
}
