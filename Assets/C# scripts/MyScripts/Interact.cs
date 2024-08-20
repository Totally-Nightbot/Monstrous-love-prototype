using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class Interact : MonoBehaviour
{
    public GameObject exclimationMark;
    public GameObject talkToMe;
    public GameObject speech;
    public GameObject questComplete;
    public GameObject hatCollectable;
    public GameObject hat;
    public Text questLine;
    public Text returnHat;

    public GameObject eToInteract;

    private bool showInteract = true;
    private bool inCollider;
    public int stepNumber = 1;


    private void Update() 
    {
        switch (stepNumber) // This switch changes depending on the step number. each step is another step in the quest
        {
            case 1:
              
                
                if (inCollider == true)
                {
                    if (showInteract == true)
                    {
                        eToInteract.gameObject.SetActive(true);
                        showInteract = false;
                    }
                    stepOne();
                   
                }

                break;

            case 2:

                stepTwo();

                break;

            case 3:
                if (inCollider == true)
                {
                    if (showInteract == true)
                    {
                        eToInteract.gameObject.SetActive(true);
                        showInteract = false;
                    }
                    stepThree();
                }
                
                break;
           
            case 4:

                break;


            default:
                //this activates if no cases are met
                Debug.LogError("YOU DUMB FUCKED UP, BITCH");
                break;
        }

    }

    private void stepOne() 
    {
       
        if (Input.GetButtonDown("Interact")) // when the player presses the interact button, then the quest will be given via an on screen UI text speech 
        {
            eToInteract.gameObject.SetActive(false);
            speech.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("Submit")) //sets it to false when they press enter and progresses the step number
        {
            speech.gameObject.SetActive(false);
            talkToMe.gameObject.SetActive(false);
            stepNumber = 2;
        }
    }
      
   private void stepTwo() // step two activates the hat collectible game object and gives the player the active quest
    {
       hatCollectable.gameObject.SetActive(true);
        questLine.gameObject.SetActive(true);
        returnHat.gameObject.SetActive(true);
    }

    public void advanceToStepThree() // when this is called, it sets the exclimation quest marker to active, sets the color green and progresses the step number
    {
      exclimationMark.gameObject.SetActive(true);
      questLine.color = Color.green;
      stepNumber = 3;
    }

    private void stepThree() //step three follows the same logic as step one except it shows a diffrent text speech
    {
        if (Input.GetButtonDown("Interact"))
        {
            eToInteract.gameObject.SetActive(false);
            returnHat.color = Color.green;
            hat.gameObject.SetActive(true);
            questComplete.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("Submit")) //on pressing enter, the quest and the diffrent game objects that are adjacent to that quest are set inactive
        {
            questComplete.gameObject.SetActive(false);
            questLine.gameObject.SetActive(false);
            returnHat.gameObject.SetActive(false);
            exclimationMark.gameObject.SetActive(false);

            stepNumber = 4;
        }

    }

    private void OnTriggerEnter(Collider other) //when the player is in the collider, set in collider to true 
    {
        inCollider = true;
    }

    private void OnTriggerExit(Collider other) //when the player leaves the collider, set in collider to false 
    {
        inCollider = false;
        speech.gameObject.SetActive(false);
        showInteract = true;
    }


}
