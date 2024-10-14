using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class dragabble: MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
  public void OnBeginDrag(PointerEventData eventdata)
    {
        Debug.Log("onBeginDrag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("onDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("onEndDrag");
    }
}
