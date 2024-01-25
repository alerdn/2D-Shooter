using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void Move(Vector2 movement, float speed, float fixedDeltaTime)
    {
        movement.y = 0f;
        Rigidbody2D rb = stateMachine.RigidBody2D;

        rb.MovePosition(rb.position + movement * (speed * fixedDeltaTime));
    }
}
