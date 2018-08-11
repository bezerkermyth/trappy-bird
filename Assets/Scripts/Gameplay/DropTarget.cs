using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTarget : MonoBehaviour {

	[SerializeField]
	private bool _isActivated = false;

	public GameObject target;
	private Vector3 targetCurrentPosition;
	
	[SerializeField]
	private float dropSpeed = 1f;

	public Rigidbody2D targetRigidbody;

	private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.gameObject.GetComponent<PlayerController> ();
		_isActivated = true;
        if (controller != null)
        {
            Debug.Log ("Player hit drop target object trigger");
            
        }
		
		
    }

	void FixedUpdate()
	{
        // Now that we have a reference we can do what ever we want with the object. For example :
		targetCurrentPosition = target.transform.position;
		
		//Debug.Log("dropspeed is " + dropSpeed);

		if(_isActivated)
		{
			//target.transform.position = targetCurrentPosition +  new Vector3(0, -dropSpeed * Time.deltaTime, 0);
			targetRigidbody.gravityScale = 5;
		}
		
        
		
    }
}
