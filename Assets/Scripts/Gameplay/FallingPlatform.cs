using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingPlatform : MonoBehaviour
{
    [SerializeField]
    private OverlapByTagNode _activationNode;

    [SerializeField]
    private float _gravity = 10;

    private Rigidbody2D _rigidbody;
    private bool _activated;
    private float _velocity;

	void Start () {
        _rigidbody = GetComponent<Rigidbody2D> ();
        _activated = false;
        _velocity = 0;
	}

    void FixedUpdate ()
    {
        if (_activationNode.Overlapped)
            _activated = true;

        if (_activated)
        {
            _velocity -= _gravity * Time.deltaTime;
            _rigidbody.velocity = new Vector2 (0, _velocity);
        }
    }
}
