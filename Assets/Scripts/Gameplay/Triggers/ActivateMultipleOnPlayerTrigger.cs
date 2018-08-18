using UnityEngine;

public class ActivateMultipleOnPlayerTrigger : MonoBehaviour
{
    [SerializeField]
    private ActivatableBehaviour[] _behavioursToActivate;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {
            for (int i = 0; i < _behavioursToActivate.Length; i++)
                _behavioursToActivate [i].Activate ();
        }
    }
}