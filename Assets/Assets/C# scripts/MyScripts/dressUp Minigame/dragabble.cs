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
       // Debug.Log("onBeginDrag");

        parentToReturnTo = this.transform.parent; //sets the parent that it will return back to
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
       // Debug.Log("onDrag");

        this.transform.position = eventData.position; //changes the position of the card to the location of the mouse

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("onEndDrag");
        this.transform.SetParent(parentToReturnTo); //returns to the parent (if this object is over the dropzone then returns to that)
        GetComponent<CanvasGroup>().blocksRaycasts = true;


    }
}
