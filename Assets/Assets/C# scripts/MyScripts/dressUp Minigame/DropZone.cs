using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Wardrobe : MonoBehaviour, IDropHandler 
{
    public dragabble.Slot typeOfClothing = dragabble.Slot.HAT;
    public int children = 1;

   public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was Dropped on " + gameObject.name);

        dragabble d = eventData.pointerDrag.GetComponent<dragabble>();

        if (d != null)
        {
            if (typeOfClothing == d.typeOfClothing && this.transform.childCount < children)
            {
                d.parentToReturnTo = this.transform;
            }
            
        }
    }
}
