using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float Speed;
    public float MaxDistance = 40f;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _playerTransform.position) > 40f)
            Destroy(this.gameObject);
    }
}
