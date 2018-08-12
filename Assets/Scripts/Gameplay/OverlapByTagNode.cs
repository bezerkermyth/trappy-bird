using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class OverlapByTagNode : MonoBehaviour
{
    public string Tag = "Crushing";
    public bool Overlapped;

    private Collider2D _collider;
    private Collider2D[] _contacts;
    private ContactFilter2D _contactFilter;

	void Start () {
        _collider = GetComponent<Collider2D> ();
        _contacts = new Collider2D[16];
        _contactFilter = new ContactFilter2D ();
        Overlapped = false;
	}

    void FixedUpdate ()
    {
        Overlapped = false;
        int numContacts = _collider.OverlapCollider (_contactFilter, _contacts);

        for (int i = 0; i < numContacts; i++)
        {
            if (_contacts [i] == null)
                continue;

            if (_contacts [i].gameObject.CompareTag (Tag))
            {
                Overlapped = true;
                break;
            }  
        }
    }
}
