using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public float MovementSpeed;
    [field: SerializeField] public float RunningSpeed;

    public Camera MainCamera { get; private set; }

    private void Start()
    {
        MainCamera = Camera.main;

        SwitchState(new PlayerMovingState(this));
    }
}
