using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class dragabble: MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform parentToReturnTo = null;
  public void OnBeginDrag(PointerEventData eventdata)
    {
        Debug.Log("onBeginDrag");

        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("onDrag");

        this.transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("onEndDrag");
        this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
