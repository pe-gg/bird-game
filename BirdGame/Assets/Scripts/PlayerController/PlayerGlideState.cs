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
        _stateMachine.rb.useGravity = false;
        Debug.Log("EnterState GLIDE");
    }

    public void ExitState()
    {
        _stateMachine.rb.useGravity = true;
        Debug.Log("ExitState GLIDE");
    }

    public void UpdateState()
    {
        Glide();
        Debug.Log("UpdateState GLIDE");
    }

    private void Glide()
    {
        _stateMachine.rb.AddForce(Vector3.right * _stateMachine.speed);
    }
}
