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
        transform.position = _target.transform.position - _offset;
    }
}
