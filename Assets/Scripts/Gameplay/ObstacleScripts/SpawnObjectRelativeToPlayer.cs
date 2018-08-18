using UnityEngine;

public class SpawnObjectRelativeToPlayer : ActivatableBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;

    [SerializeField]
    private Vector3 _offsetFromPlayer = new Vector3(30, 0, 0);

    private Transform _playerTransform;

    protected override void OnStart ()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void OnActivate ()
    {
        Instantiate (_projectilePrefab, _playerTransform.position + _offsetFromPlayer, Quaternion.identity);
    }
}
