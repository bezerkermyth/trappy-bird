using UnityEngine;

public class KillPlayerOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.gameObject.GetComponent<PlayerController> ();

        if (controller != null)
            controller.Die ();
    }
}
