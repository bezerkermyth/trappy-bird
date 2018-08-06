using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.gameObject.GetComponent<PlayerController> ();

        if (controller != null)
        {
            Debug.Log ("Player entered kill zone!");
            controller.Die ();
        }
    }
}
