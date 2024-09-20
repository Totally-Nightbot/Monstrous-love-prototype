using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiegeticUI : MonoBehaviour
{
   
    public GameObject iconPrefab;
    private GameObject iconObject;
    public Vector3 displayOffset = new Vector3(0, 0.6f, 0);
    void OnEnable()
    {
        Canvas canvas = FindObjectOfType<Canvas>(); 
        if (canvas == null)
        {
            Debug.Log("Error finding Canvas in scene.");
            return;
        }
        iconObject = Instantiate(iconPrefab, canvas.transform);
    }
    // Update is called once per frame
    void Update()
    {
    
        if (iconObject == null)
            {
                return;
            }
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(
        this.transform.position + displayOffset);
        iconObject.transform.position = screenPosition;
    }
        
    void OnDisable()
    {
        if (iconObject != null)
        {
            Destroy(iconObject);
        }
    }
}
