using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingPlatformOnTrigger : MonoBehaviour
{
    [SerializeField]
    private OverlapByTagNode _activationNode;

    [SerializeField]
    private float _gravity = 10;

    private Rigidbody2D _rigidbody;
    private bool _activatedOnStart = false;
    private float _velocity;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player triggered");
            _velocity = 0;
            _activatedOnStart = true;
            _rigidbody.gravityScale = _gravity;
        }
    }


    void FixedUpdate()
    {
        if (_activatedOnStart)
        {
            _rigidbody.gravityScale = 1;
            _velocity -= _gravity * Time.deltaTime;
            _rigidbody.velocity = new Vector2(0, _velocity);
        }
    }
}
