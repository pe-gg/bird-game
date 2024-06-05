using UnityEngine;

public class PlayerFallState : IState
{
    private PlayerStateMachine _stateMachine;

    //PlayerFallState constructor
    public PlayerFallState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void EnterState()
    {
        Debug.Log("EnterState FALL");
        _stateMachine.updraftSystem.DownDraft();
    }

    public void ExitState()
    {
        Debug.Log("ExitState FALL");
        _stateMachine.updraftSystem.StopCoroutines();
    }

    public void UpdateState()
    {
        Debug.Log("UpdateState FALL");
    }
}
