using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Rigidbody2D RigidBody2D { get; private set; }
    [field: SerializeField] public Gun Gun { get; private set; }
    [field: SerializeField] public float MovementSpeed;
    [field: SerializeField] public float RunningSpeed;
    [SerializeField] private MinorRune _rune;
    
    private void Start()
    {
        Debug.Log($"GetDamage: {Gun.GetDamage()}");
        Gun.AddRune(_rune);
        Debug.Log($"GetDamage: {Gun.GetDamage()}");

        Gun.Shoot();

        SwitchState(new PlayerMovingState(this));
    }
}
