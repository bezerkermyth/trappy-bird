using UnityEngine;

public class PlayerController : PhysicsObject2D
{
    public float MoveSpeed = 7;
    public float JumpPower = 7;
    public bool Dead;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        Dead = false;
        _spriteRenderer.enabled = true;
    }

    protected override void ComputeVelocity()
    {
        TargetVelocity.x = MoveSpeed;

        if (Input.GetButtonDown ("Jump"))
            Velocity.y = JumpPower;
        //else if (Velocity.y > 0)
        //    Velocity.y = Velocity.y * 0.5f;
    }

    public void Die() {
        Dead = true;
        _spriteRenderer.enabled = false;
    }
}
