using UnityEngine;

public class PlayerMoveUpState : IState
{
    private PlayerStateMachine _stateMachine;

    //PlayerMoveUpState constructor
    public PlayerMoveUpState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void EnterState()
    {
        Debug.Log("EnterState UP");
    }

    public void ExitState()
    {
        Debug.Log("ExitState UP");
    }

    public void UpdateState()
    {
        Debug.Log("UpdateState UP");
    }
}
