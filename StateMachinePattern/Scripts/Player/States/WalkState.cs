using UnityEngine;

public class WalkState : BaseState<EPlayerState>
{
    private PlayerMovementStateMachine Context;

    public WalkState(PlayerMovementStateMachine context,  EPlayerState stateKey) : base(stateKey)
    {
        Context = context;
    }

    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
        Debug.Log("WalkState");

        if(Context.Rigidbody.velocity.magnitude > Context.MaxSpeed)
        {
            Context.Rigidbody.velocity = Vector3.ClampMagnitude(Context.Rigidbody.velocity, Context.MaxSpeed);
        }

        Context.Rigidbody.AddForce(Context.MovementVector, ForceMode.Force);
    }

    public override void ExitState()
    {
    }

    public override EPlayerState GetNextState()
    {
        // Switch to Idle
        if(Context.MovementVector.IsZero()) {
            return EPlayerState.Idle;
        }

        return EPlayerState.Walk;
    }

    public override void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider other)
    {
        throw new System.NotImplementedException();
    }
}
