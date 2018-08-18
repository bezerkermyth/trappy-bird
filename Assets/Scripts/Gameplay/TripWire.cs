using UnityEngine;

public class TripWire : MonoBehaviour
{
    private Transform PlayerTransform;
    public GameObject Projectile;

    private void Start()
    {
        PlayerTransform = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController _controller = collision.gameObject.GetComponent<PlayerController>();

        if (_controller != null)
        {
            SpawnProjectile(Projectile);
            this.gameObject.SetActive(false);
        }
    }

    // Spawns projectile, behavior of projectile once spawned is handled by ProjectileBehavior script
    void SpawnProjectile(GameObject _projectile)
    {
        Instantiate(_projectile, 
                    new Vector3(PlayerTransform.position.x + 30f,
                                PlayerTransform.position.y,
                                0f),
                    Quaternion.identity);
    }
}
