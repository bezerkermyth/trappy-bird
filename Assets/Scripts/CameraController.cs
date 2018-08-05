using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //    if (Input.GetKey(KeyCode.LeftArrow))
        //    {
        //        Vector3 position = this.transform.position;
        //        position.x = position.x -0.3f;
        //        this.transform.position = position;
        //    }
        //    else if (Input.GetKey(KeyCode.RightArrow))
        //    {
        //        Vector3 position = this.transform.position;
        //        position.x = position.x + 0.3f;
        //        this.transform.position = position;
        //    }
        Vector3 position = this.transform.position;
        position.x = position.x + speed;
        this.transform.position = position;
}
}
