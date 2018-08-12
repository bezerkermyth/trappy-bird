using UnityEngine;
using System.Collections;

public class VisibleOnTrigger : MonoBehaviour
{
    public string _startSortingLayer = "Background0";
    public string _triggerSortingLayer = "Background2";
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sortingLayerName = _startSortingLayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("entered spikes");
        Debug.Log(sprite.sortingLayerName);
        Debug.Log(sprite.sortingOrder);
        if (sprite)
            sprite.sortingLayerName = _triggerSortingLayer;
    }




 
// public class SortingOrderScript : MonoBehaviour
//{
//    public int sortingOrder = 0;
//    private SpriteRenderer sprite;

//    void Start()
//    {
//        sprite = GetComponent<SpriteRenderer>();
//    }

//    void Update()
//    {
//        if (sprite)
//            sprite.sortingOrder = sortingOrder;
//    }
//}

}
