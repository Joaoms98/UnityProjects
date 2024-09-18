using UnityEngine;

public class IdleState : BaseState<EPlayerState>
{
    private PlayerMovementStateMachine Context;

    public IdleState(PlayerMovementStateMachine context,  EPlayerState stateKey) : base(stateKey)
    {
        Context = context;
    }
    
    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
        Debug.Log("IdleState");
    }

    public override void ExitState()
    {
    }

    public override EPlayerState GetNextState()
    {
        // Switch to Walking
        if(!Context.MovementVector.IsZero()) {
            return EPlayerState.Walk;
        }

        return EPlayerState.Idle;
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

    public override void OnTriggerExit(Collider other)
    {
    }

    public override void OnTriggerStay(Collider other)
    {
    }
}
