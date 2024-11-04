using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DropZone : MonoBehaviour, IDropHandler
{ 
   public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was Dropped on " + gameObject.name);

        dragabble d = eventData.pointerDrag.GetComponent<dragabble>(); // gets the componet of draggable

        if (d != null) // if it doesnt = null then set their parent to return to to this object 
        {
             d.parentToReturnTo = this.transform;
 
            
        }
    }
}
