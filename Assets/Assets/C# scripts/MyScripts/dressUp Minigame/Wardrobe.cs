using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DropZone : MonoBehaviour, IDropHandler
{ 
   public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " was Dropped on " + gameObject.name);

        dragabble d = eventData.pointerDrag.GetComponent<dragabble>();

        if (d != null)
        {
             d.parentToReturnTo = this.transform;
 
            
        }
    }
}
