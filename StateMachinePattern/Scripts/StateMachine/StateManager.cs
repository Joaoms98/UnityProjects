using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager<EState> : MonoBehaviour where EState: Enum
{
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
    protected BaseState<EState> CurrentState;

    public void UpdateState()
    {
        EState nextStateKey = CurrentState.GetNextState();

        if (nextStateKey != null && !nextStateKey.Equals(CurrentState.StateKey))
        {
            ChangeState(States[nextStateKey]);
        }

        CurrentState?.UpdateState();
    }

    public void ChangeState(BaseState<EState> newState) {
        CurrentState?.ExitState();
        CurrentState = newState;
        CurrentState?.EnterState();
    }

    public void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnter(other);
    }

    public void OnTriggerStay(Collider other)
    {
        CurrentState.OnTriggerStay(other);
    }

    public void OnTriggerExit(Collider other)
    {
        CurrentState.OnTriggerExit(other);
    }
}
