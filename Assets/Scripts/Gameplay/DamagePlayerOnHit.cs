using UnityEngine;

public class DamagePlayerOnHit : MonoBehaviour {

	[SerializeField]
    private int _damage = 1;
	void OnCollisionEnter2D (Collision2D collision)
	{
        PlayerController controller = collision.gameObject.GetComponent<PlayerController> ();

        if (controller != null)
            controller.TakeDamage (_damage);
    }
}
