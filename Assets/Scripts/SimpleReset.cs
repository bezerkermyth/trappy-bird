using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public GameObject target;

    // Update is called once per frame
    void Update () {
		        if (!target)
        {
            Application.LoadLevel("SampleScene");
        }
	}


    


    //void Reset()
    //{
    //    //Output the message to the Console
    //    Debug.Log("Reset");
    //    if (!target)
    //        target = GameObject.FindWithTag("Player");
    //}
}

