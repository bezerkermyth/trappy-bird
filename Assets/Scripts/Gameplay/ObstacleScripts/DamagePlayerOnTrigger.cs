using UnityEngine;

public class DamagePlayerOnTrigger : MonoBehaviour
{
    [SerializeField]
    private int _damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.gameObject.GetComponent<PlayerController> ();

        if (controller != null)
            controller.TakeDamage (_damage);
    }
}
