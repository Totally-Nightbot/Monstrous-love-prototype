using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWith : MonoBehaviour


{
    public bool inTextBox = false;
    public bool inCollider;
    public GameObject textBox;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inCollider == true)
        {
            stepOne();
            Debug.Log("Collider Triggered");
        }



    }

    private void stepOne()
    {

        if (Input.GetButtonDown("Interact")) // when the player presses the interact button, then the quest will be given via an on screen UI text speech 
        {
            inTextBox = true;
            textBox.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("Submit")) //sets it to false when they press enter and progresses the step number
        {
            inTextBox = false;
            textBox.gameObject.SetActive(false);
          
            
        }

    }

        private void OnTriggerEnter(Collider other) //when the player is in the collider, set in collider to true 
    {
        inCollider = true;
    }

    private void OnTriggerExit(Collider other) //when the player leaves the collider, set in collider to false 
    {
        inCollider = false;
       
    }
}
