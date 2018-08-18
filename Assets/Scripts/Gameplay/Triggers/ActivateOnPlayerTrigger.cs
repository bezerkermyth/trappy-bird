using UnityEngine;

public class ActivateOnPlayerTrigger : MonoBehaviour
{
    [SerializeField]
    private ActivatableBehaviour _behaviourToActivate;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("Player"))
            _behaviourToActivate.Activate ();
    }
}