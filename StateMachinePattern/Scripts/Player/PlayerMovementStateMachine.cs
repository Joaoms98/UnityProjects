using UnityEngine;

public class PlayerMovementStateMachine : StateManager<EPlayerState>
{
    [SerializeField] public Rigidbody Rigidbody;
    [SerializeField] public CapsuleCollider RootCollider;
    [HideInInspector] public Vector3 MovementVector;
    [SerializeField] public float MovementSpeed = 10;
    [SerializeField] public float MaxSpeed = 10;

    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        InitializeStates();
    }

    void Update()
    {
        // Create input vector
        bool isForward = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        bool isBack = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool isLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        bool isRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        float inputX = isRight ? 1 : isLeft ? -1 : 0;
        float inputZ = isForward ? 1 : isBack ? -1 : 0;

        // Create vector
        MovementVector = new Vector3(inputX , 0, inputZ);
        MovementVector *= MovementSpeed;

        UpdateState();
    }

    private void InitializeStates()
    {
        States.Add(EPlayerState.Idle, new IdleState(this, EPlayerState.Idle));
        States.Add(EPlayerState.Walk, new WalkState(this, EPlayerState.Walk));
        States.Add(EPlayerState.Jump, new JumpState(this, EPlayerState.Jump));
        CurrentState = States[EPlayerState.Idle];
    }
}
