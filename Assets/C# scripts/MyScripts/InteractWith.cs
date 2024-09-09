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
    private bool choice = false;

    public List<string> writtenDialog;

    public GameObject textBox;
    public TextMeshProUGUI talking;
    public TextMeshProUGUI option1txt;
    public TextMeshProUGUI option2txt;
    public Buttoninteractions Buttoninteractions;

    public int text = 1;
    public int dialog = 6;
    public int i = 0;
    private int choiceNumber = 0;



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

        //switch (text) // the main text blocks of the chatting stuff (ctrl + k + u to uncomment)
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
        if ((Input.GetButtonDown("Submit") && choice == false && inCollider == true && text < dialog) || (Buttoninteractions.option1clicked == true || Buttoninteractions.option2clicked == true) )
        {
           // Buttoninteractions.option2clicked = false;
           // Buttoninteractions.option1clicked = false;

            if (i < dialog)
            {
                i++;
            }
            
            talking.text = writtenDialog[i];
           

            if (text == 4) //Change the second number when you want to implament a new button prompt (place it in the space of sequence you want the choice to be)  
            {
                ButtonOptions();

            }


        }
        else if (text >= dialog)
        {
            inTextBox = false;
            textBox.gameObject.SetActive(false);
            Buttoninteractions.OptionOne.gameObject.SetActive(false);
            Buttoninteractions.OptionTwo.gameObject.SetActive(false);
        }
    }



    void EnterInteract()
    {

        if (Input.GetButtonDown("Interact")) // when the player presses the interact button, then the quest will be given via an on screen UI text speech 
        {
            inTextBox = true;
            textBox.gameObject.SetActive(true);
            talking.text = writtenDialog[i];
        }

        if (Input.GetButtonDown("Submit") && choice == false && text < dialog) //sets it to false when they press enter and progresses the step number
        {
            text++;
        }
        /*
                else if (text >= dialog)
                {
                    inTextBox = false;
                    textBox.gameObject.SetActive(false);
                    Buttoninteractions.OptionOne.gameObject.SetActive(false);
                    Buttoninteractions.OptionTwo.gameObject.SetActive(false);
                }
        */
    }


    void ButtonOptions()
    {
        ButtonActivate();
        choice = true;
        option1txt.text = ("wait why is it closed?");
        option2txt.text = ("ok, have a good day");

        if (Buttoninteractions.option1clicked == true)
        {
            ButtonDeactiveate();
            text++;
            choice = false;
            //Buttoninteractions.option1clicked = false;
        }
        else if (Buttoninteractions.option2clicked == true)
        {
            ButtonDeactiveate();
            text++;
            i++;
            choice = false;
            //Buttoninteractions.option2clicked = false;
        }
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

    void OnTriggerEnter(Collider other) //when the player is in the collider, set in collider to true 
    {
        inCollider = true;
    }

    void OnTriggerExit(Collider other) //when the player leaves the collider, set in collider to false 
    {
        inCollider = false;

    }

}


