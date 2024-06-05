using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpState : IState
{

    private PlayerStateMachine _stateMachine;

    public PlayerUpState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public void EnterState()
    {
        Debug.Log("EnterState Up");
        _stateMachine.updraftSystem.UpDraft();
    }

    public void ExitState()
    {
        Debug.Log("ExitState Up");
        _stateMachine.updraftSystem.StopCoroutines();
    }

    public void UpdateState()
    {
        Debug.Log("UpdateState Up");
    }
}
