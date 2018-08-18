using UnityEngine;

public class DamagePlayerOnCollision : MonoBehaviour
{
    public int Damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController controller = collision.gameObject.GetComponent<PlayerController> ();

        if (controller != null)
            controller.TakeDamage (Damage);
    }
}
