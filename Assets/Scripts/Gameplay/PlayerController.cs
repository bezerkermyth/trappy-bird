using UnityEngine;

public class PlayerController : PhysicsObject2D
{
    public float MaxMoveSpeed = 7;
    public float Acceleration = 4;
    public float IdleDeceleration = 14;
    public bool QuickTurn = true;
    public float QuickTurnFactor = 2.5f;
    public float JumpPower = 7;
    public bool Dead;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private LivesCounter _livesCounter;

    [SerializeField]
    private CrushNode _crushNodeA;

    [SerializeField]
    private CrushNode _crushNodeB;

    void Start()
    {
        Dead = false;
        _spriteRenderer.enabled = true;
    }

    //Keep input code in this method.
    protected override void ComputeVelocity()
    {
        HandleCrushDeaths ();

        float moveDirection = Input.GetAxis ("Horizontal");

        if (moveDirection != 0)
        {
            if (QuickTurn)
                HandleMoveQuickTurn (moveDirection);
            else
                HandleMove (moveDirection);
        } 
        else HandleDecelerate ();

        if (Input.GetButtonDown ("Jump"))
            Jump ();
    }

    //Does not handle zero input (that is for HandleDecelerate)
    void HandleMove (float direction)
    {
        float velocityDelta = direction * Acceleration * Time.deltaTime;

        TargetVelocity.x = Velocity.x + velocityDelta;
        if (Mathf.Abs (TargetVelocity.x) > MaxMoveSpeed)
            TargetVelocity.x = Mathf.Sign (TargetVelocity.x) * MaxMoveSpeed;
    }

    //Does not handle zero input (that is for HandleDecelerate)
    void HandleMoveQuickTurn (float direction)
    {
        float velocityDelta = direction * Acceleration * Time.deltaTime;

        if (Mathf.Sign (velocityDelta) != Mathf.Sign (Velocity.x))
            velocityDelta *= QuickTurnFactor;

        TargetVelocity.x = Velocity.x + velocityDelta;
        if (Mathf.Abs (TargetVelocity.x) > MaxMoveSpeed)
            TargetVelocity.x = Mathf.Sign (TargetVelocity.x) * MaxMoveSpeed;
    }

    //Only handles zero input
    void HandleDecelerate()
    {
        float velocityDelta = Mathf.Sign (Velocity.x) * IdleDeceleration * Time.deltaTime;

        if (Mathf.Abs (velocityDelta) >= Mathf.Abs (Velocity.x))
            TargetVelocity.x = 0;
        else
            TargetVelocity.x = Velocity.x - velocityDelta;
    }

    void Jump () 
    {
        Velocity.y = JumpPower;
    }

    void HandleCrushDeaths ()
    {
        if (_crushNodeA.Overlapped && _crushNodeB.Overlapped)
            Die ();
    }

    public void TakeDamage(int amount = 1)
    {
        _livesCounter.UpdateLives (_livesCounter.NumLives - amount);

        if (_livesCounter.NumLives < 1)
            Die ();
    }

    public void Die()
    {
        Dead = true;
        _spriteRenderer.enabled = false;
    }
}
