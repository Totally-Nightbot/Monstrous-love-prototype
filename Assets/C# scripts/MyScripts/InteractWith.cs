using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class InteractWith : MonoBehaviour


{

    public bool inTextBox = false;
    private bool inCollider;
    public List <string> writtenDialog; 


    public GameObject textBox;
    public TextMeshProUGUI talking;
    public TextMeshProUGUI option1txt;
    public TextMeshProUGUI option2txt;
    public Buttoninteractions Buttoninteractions;

    private int text = 1;
    private int dialog = 6;
    private int i = 0;

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
        PotentialModularDialog();

        //switch (text) // The main text blocks of the chatting stuff (ctrl + K + U to uncomment)
        //{
        //    case 1:
        //        talking.text = (writtenDialog[0]);

        //        break;

        //    case 2:
        //        talking.text = (writtenDialog[1]);

        //        break;

        //    case 3:
        //        talking.text = (writtenDialog[2]);

        //        break;

        //    case 4:

        //        ButtonActivate();

        //        choice = true;
        //        option1txt.text = ("wait why is it closed?");
        //        option2txt.text = ("ok, have a good day");

        //        if (Buttoninteractions.option1clicked == true)
        //        {
        //            choice = false;
        //            text++;
        //        }
        //        else if (Buttoninteractions.option2clicked == true)
        //        {
        //            choice = false;

        //            ButtonDeactiveate();


        //            text = dialog;
        //        }

        //        break;

        //    case 5:
        //        ButtonDeactiveate();

        //        talking.text = (writtenDialog[3]);
        //        break;

        //    case 6:
        //        talking.text = (writtenDialog[4]);
        //        break;

        //    default:
        //        Debug.LogError("out of case area");

        //        break;
        //}

    }

    void PotentialModularDialog()
    {
        if (inCollider == true)
        {
            if (Input.GetButtonDown("Submit")) //sets it to false when they press enter and progresses the step number
            {
                if ( choice == false)
                {
                    
                    if (text < dialog)
                    {
                        i++;
                        talking.text = writtenDialog[i];

                        
                        
                        // Include code to prompt questions 
                        // Could check if the written dialog equals a certain number then enters the button mode
                        // button answers would be in another list
                        // if text equals a certain number then run the button prompts?

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
