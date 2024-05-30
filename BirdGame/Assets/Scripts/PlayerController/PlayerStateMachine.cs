using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] public float speed = 1;

    public Rigidbody rb;
    public PlayerIdleState idleState;
    public PlayerGlideState glideState;
    public PlayerFallState fallState;

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

        rb = GetComponent<Rigidbody>();

        //Set player default state
        SetState(idleState);
    }

    private void Update()
    {
        _currentState?.UpdateState();
    }
}
