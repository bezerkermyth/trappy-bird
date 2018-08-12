using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class ChangeLayerOnTrigger : MonoBehaviour
{
    public string InitialSortingLayer = "Background0";
    public string TriggerSortingLayer = "Background2";

    private SpriteRenderer _sprite;

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.sortingLayerName = InitialSortingLayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Sorting layer changed!");
            Debug.Log(_sprite.sortingLayerName);
            Debug.Log(_sprite.sortingOrder);
            if (_sprite)
                _sprite.sortingLayerName = TriggerSortingLayer;
        }
    }
}
