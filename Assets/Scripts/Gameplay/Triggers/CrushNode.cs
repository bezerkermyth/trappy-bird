using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CrushNode : MonoBehaviour
{
    public bool Overlapped;
    private Collider2D _collider;
    private Collider2D[] _contacts;
    private ContactFilter2D _contactFilter;

	void Start ()
    {
        Overlapped = false;
        _collider = GetComponent<Collider2D> ();
        _contacts = new Collider2D[8];
        _contactFilter.useTriggers = true;
        _contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        _contactFilter.useLayerMask = true;
	}

    void FixedUpdate ()
    {
        Overlapped = _collider.OverlapCollider (_contactFilter, _contacts) > 0;
    }
}
