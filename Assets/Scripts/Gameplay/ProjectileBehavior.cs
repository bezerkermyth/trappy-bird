using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float Speed;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left.normalized * Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _playerTransform.position) > 40f)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.gameObject.GetComponent<PlayerController>();

        if (controller != null)
            controller.Die();
    }
}
