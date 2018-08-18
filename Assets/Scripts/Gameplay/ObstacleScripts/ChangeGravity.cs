using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ChangeGravity : ActivatableBehaviour
{
    public float InitialGravityScale = 0f;
    public float TriggerGravityScale = 5f;
    private Rigidbody2D _rigidbody;

    protected override void OnStart ()
    {
        _rigidbody = GetComponent<Rigidbody2D> ();
        _rigidbody.gravityScale = InitialGravityScale;
    }

    protected override void OnActivate ()
    {
        _rigidbody.gravityScale = TriggerGravityScale;
    }

    protected override void OnDeactivate ()
    {
        _rigidbody.gravityScale = InitialGravityScale;
    }
}
