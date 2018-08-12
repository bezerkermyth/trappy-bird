using UnityEngine;

public class ConstantMove : MonoBehaviour
{
    [SerializeField]
    private float _unitsPerSecond = 1;

    [SerializeField]
    private Vector2 _direction = Vector2.right;

	void Update ()
    {
        transform.Translate (_direction * _unitsPerSecond * Time.deltaTime);
	}
}
