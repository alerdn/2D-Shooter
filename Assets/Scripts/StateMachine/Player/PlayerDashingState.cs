using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashingState : PlayerBaseState
{
    private readonly int DashHash = Animator.StringToHash("dash");
    private float _dashSpeed = 50f;
    private float _dashDuration = .2f;

    private Vector2 _movement;
    private float _currentVelocity;

    public PlayerDashingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        _movement = stateMachine.InputReader.Movement;
        stateMachine.Animator.CrossFadeInFixedTime(DashHash, .01f);
        stateMachine.StartCoroutine(StopDashing());
    }

    public override void Tick(float deltaTime)
    {
        float speed = Mathf.SmoothDamp(_dashSpeed, stateMachine.MovementSpeed, ref _currentVelocity, _dashDuration);
        Move(_movement, speed, deltaTime);
    }

    public override void Exit() { }

    private IEnumerator StopDashing()
    {
        if (_movement != Vector2.zero)
        {
            yield return new WaitForSeconds(_dashDuration);
        }

        stateMachine.SwitchState(new PlayerMovingState(stateMachine));
    }
}
