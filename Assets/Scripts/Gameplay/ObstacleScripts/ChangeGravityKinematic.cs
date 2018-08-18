using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ChangeGravityKinematic : ActivatableBehaviour
{
    public float InitialGravityScale = 0f;
    public float TriggerGravityScale = 5f;
    public bool ResetPositionOnChange = true;
    public bool ResetVelocityOnChange = true;

    private Rigidbody2D _rigidbody;
    private Vector3 _initialPosition;
    private float _gravityScale;

    protected override void OnStart ()
    {
        _rigidbody = GetComponent<Rigidbody2D> ();
        _initialPosition = transform.position;
        _gravityScale = InitialGravityScale;
    }

    protected override void OnFixedUpdate ()
    {
        _rigidbody.velocity = _rigidbody.velocity + (Physics2D.gravity * _gravityScale * Time.fixedDeltaTime);
    }

    protected override void OnActivate ()
    {
        _gravityScale = TriggerGravityScale;
        if (ResetPositionOnChange)
            _rigidbody.position = _initialPosition;
        if (ResetVelocityOnChange)
            _rigidbody.velocity = Vector3.zero;
    }

    protected override void OnDeactivate ()
    {
        _gravityScale = InitialGravityScale;
        if (ResetPositionOnChange)
            _rigidbody.position = _initialPosition;
        if (ResetVelocityOnChange)
            _rigidbody.velocity = Vector3.zero;
    }
}
