using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;


public class dragabble: MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
   [HideInInspector] public Transform parentToReturnTo = null;
     public enum Slot { HAT, CHEST};
    public Slot typeOfClothing = Slot.HAT;


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
