using UnityEngine;

public class DropTarget : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _target;
    private bool _activated = false;

	private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
		    _activated = true;
    }

	void Update ()
	{
		if (_activated)
            _target.gravityScale = 5;
    }
}
