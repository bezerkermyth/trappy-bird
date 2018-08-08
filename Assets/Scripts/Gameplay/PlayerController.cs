using UnityEngine;

public class PlayerController : PhysicsObject2D
{
    public float MoveSpeed = 7;
    public float JumpPower = 7;
    public bool Dead;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private LivesCounter _livesCounter;

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
    }

    public void TakeDamage(int amount = 1)
    {
        _livesCounter.UpdateLives (_livesCounter.NumLives - amount);

        if (_livesCounter.NumLives < 1)
            Die ();
    }

    public void Die() {
        Dead = true;
        _spriteRenderer.enabled = false;
    }
}
