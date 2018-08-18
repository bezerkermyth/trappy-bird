using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class ChangeSortingLayer : ActivatableBehaviour
{
    public string InitialSortingLayer = "Default";
    public string TriggerSortingLayer = "Gameplay";

    private SpriteRenderer _sprite;

    protected override void OnStart ()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _sprite.sortingLayerName = InitialSortingLayer;
    }

    protected override void OnActivate ()
    {
        _sprite.sortingLayerName = TriggerSortingLayer;
    }

    protected override void OnDeactivate ()
    {
        _sprite.sortingLayerName = InitialSortingLayer;
    }
}
