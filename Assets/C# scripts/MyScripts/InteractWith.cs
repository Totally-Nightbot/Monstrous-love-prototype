using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractWith : MonoBehaviour


{

    public bool inTextBox = false;
    public bool inCollider;
    
    public GameObject textBox;
    public TextMeshProUGUI talking;
    public TextMeshProUGUI option1txt;
    public TextMeshProUGUI option2txt;
    public Buttoninteractions Buttoninteractions;

    private int text = 1;
    private int dialog = 6;

    private bool choice = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      

        if (inCollider == true)
        {
            EnterInteract();
          //  Debug.Log("Collider Triggered");
        }

        switch(text) // The main text blocks of the chatting stuff
        {
            case 1:
                talking.text = ("Hey there! sorry we are closed :(");

                break;

            case 2:
                talking.text = ("If you would like to come back another day, then you're welcome to!");

                break;

            case 3:
                talking.text = ("But at this moment, you can't come in.");

                break;

            case 4:

                ButtonActivate();

                choice = true;
                option1txt.text = ("wait why is it closed?");
                option2txt.text = ("ok, have a good day");

                if (Buttoninteractions.option1clicked == true)
                {
                    choice = false;
                    text++;
                }
                else if (Buttoninteractions.option2clicked == true)
                {
                    choice = false;

                    ButtonDeactiveate();


                    text = dialog;
                }
                
                break;

            case 5:
                ButtonDeactiveate();

                talking.text = ("well the develo- I mean resturant owners aren't ready for this area to be open");
                break;

            case 6:
                talking.text = ("Sorry for the inconvience, have a good day");
                break;

            default:
                Debug.LogError("out of case area");

                break;
        }

    }

    private void EnterInteract()
    {

        if (Input.GetButtonDown("Interact")) // when the player presses the interact button, then the quest will be given via an on screen UI text speech 
        {
            inTextBox = true;
            textBox.gameObject.SetActive(true);
        }

        if (Input.GetButtonDown("Submit")) //sets it to false when they press enter and progresses the step number
        {
            if (choice == false)
            {
                if (text < dialog)
                {
                    text++;
                }
                else if (text >= dialog)
                {
                    inTextBox = false;
                    textBox.gameObject.SetActive(false);
                    Buttoninteractions.OptionOne.gameObject.SetActive(false);
                    Buttoninteractions.OptionTwo.gameObject.SetActive(false);
                    

                }
            }
           

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

    void ButtonActivate()
    {
        Buttoninteractions.OptionOne.gameObject.SetActive(true);
        Buttoninteractions.OptionTwo.gameObject.SetActive(true);
        talking.gameObject.SetActive(false);
    }

    void ButtonDeactiveate()
    {
        Buttoninteractions.OptionOne.gameObject.SetActive(false);
        Buttoninteractions.OptionTwo.gameObject.SetActive(false);
        talking.gameObject.SetActive(true);
    }
}
