using System.Collections;
using UnityEngine;

public class PlayerGlideState : IState
{
    private PlayerStateMachine _stateMachine;

    //PlayerGlideState constructor
    public PlayerGlideState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void EnterState()
    {
        Debug.Log("EnterState GLIDE");
        _stateMachine.glidingSystem.Glide();
    }

    public void ExitState()
    {
        Debug.Log("ExitState GLIDE");
        _stateMachine.glidingSystem.StopCoroutines();
    }

    public void UpdateState()
    {
        Debug.Log("UpdateState GLIDE");
    }

}
