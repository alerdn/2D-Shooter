using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State _currentState;

    protected virtual void Update()
    {
        _currentState?.Tick(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _currentState?.FixedTick(Time.fixedDeltaTime);
    }

    public void SwitchState(State newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
    }
}
