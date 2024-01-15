using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void Move(Vector3 movement, float speed, float deltaTime)
    {
        Vector3 forward = stateMachine.MainCamera.transform.forward;
        Vector3 right = stateMachine.MainCamera.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        movement = forward * movement.y + right * movement.x;
        stateMachine.Controller.Move(movement * (speed * deltaTime));
    }
}
