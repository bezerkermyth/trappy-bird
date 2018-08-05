using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entered collision zone");
        if (collision.gameObject.tag == "Player")
            Destroy(collision.gameObject);
    }


}
