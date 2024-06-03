using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerIdleState idleState;
    public PlayerGlideState glideState;
    public PlayerFallState fallState;
    public PlayerUpState upState;
    public UpdraftSystem updraftSystem;
    public GlidingSystem glidingSystem;

    private IState _currentState;

    public void SetState(IState newState)
    {
        _currentState?.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }

    private void Awake()
    {
        idleState = new PlayerIdleState(this);
        glideState = new PlayerGlideState(this);
        fallState = new PlayerFallState(this);
        upState = new PlayerUpState(this);

        glidingSystem = GetComponent<GlidingSystem>();
        updraftSystem = GetComponent<UpdraftSystem>();

        //Set player default state
        SetState(idleState);
    }

    private void Update()
    {
        _currentState?.UpdateState();
    }
}
