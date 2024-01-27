using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingState : PlayerBaseState
{
    private readonly int MovementTreeHash = Animator.StringToHash("MovementBlendTree");
    private readonly int MovementSpeedHash = Animator.StringToHash("MovementSpeed");
    private Vector2 _movement;

    public PlayerMovingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InputReader.DashEvent += StartDash;

        stateMachine.Animator.CrossFadeInFixedTime(MovementTreeHash, .1f);
    }

    public override void Tick(float deltaTime)
    {
        _movement = stateMachine.InputReader.Movement;

        if (_movement != Vector2.zero)
            stateMachine.Animator.transform.rotation = Quaternion.Euler(_movement.x > 0 ? 1f : -1f, 1f, 1f);


        stateMachine.Animator.SetFloat(MovementSpeedHash, _movement != Vector2.zero ? 1 : 0, .05f, deltaTime);
    }

    public override void FixedTick(float fixedDeltaTime)
    {
        float speed = stateMachine.InputReader.IsRunning ? stateMachine.RunningSpeed : stateMachine.MovementSpeed;
        Move(_movement, speed, fixedDeltaTime);
    }

    public override void Exit()
    {
        stateMachine.InputReader.DashEvent -= StartDash;
    }

    private void StartDash()
    {
        stateMachine.SwitchState(new PlayerDashingState(stateMachine));
    }
}
