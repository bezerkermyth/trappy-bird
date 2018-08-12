using UnityEngine;

public class DropTarget : MonoBehaviour {

	[SerializeField]
	private bool _isActivated = false;

	public Rigidbody2D target;

	private void OnTriggerEnter2D(Collider2D collision)
    {
		_isActivated = true;
    }

	void Update()
	{
		if(_isActivated)
		{
			target.gravityScale = 5;
		}
    }
}
