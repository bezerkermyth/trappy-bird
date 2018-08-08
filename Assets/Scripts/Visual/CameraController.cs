using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private PlayerController _target;

    private Vector3 _offset;

	void Start ()
    {
        _offset = _target.transform.position - transform.position;
	}

    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.x = _target.transform.position.x - _offset.x;
        transform.position = newPos;
    }
}
