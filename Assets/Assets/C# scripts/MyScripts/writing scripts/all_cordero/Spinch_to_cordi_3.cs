﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spinch_to_cordi_3 : MonoBehaviour
{
public Cretura cretura;
public Spinch spinch;

[HideInInspector] public bool inTextBox = false;
    [SerializeField] bool inCollider = false;
private bool choice = false;
private bool advance = false;

    [Header("Writting")]
    [SerializeField] List<string> writtenDialog;
    [SerializeField] List<string> dialogOptions1;
    [SerializeField] List<string> dialogOptions2;

    [Header("npcs")]
    [SerializeField] private GameObject Test_NPC_spinch;
    [SerializeField] private GameObject plant1_NPC;
    [SerializeField] private GameObject plant2_NPC;
    [SerializeField] private GameObject codero_NPC;

    [Header("other stuff")]
    public GameObject textBox;
public TextMeshProUGUI talking;
public TextMeshProUGUI option1txt;
public TextMeshProUGUI option2txt;
public Buttoninteractions Buttoninteractions;
public GameObject floatingBubble;

    [SerializeField] private int text = 1;
    [SerializeField] private int w = 0;
    [SerializeField] private int q = 0;

[SerializeField] private int dialog = 12; //Make sure this matches the amount of cases


void Update()
{

    if (inCollider == true)
    {
        EnterInteract();
           
            plant1_NPC.SetActive(false);
            plant2_NPC.SetActive(false);
            codero_NPC.SetActive(false);
            spinch.all.SetActive(true);
            GetComponent<Buttoninteractions>().enabled = true;

            if (inTextBox == false)
            {
                floatingBubble.SetActive(true);
            }
        }
    else if (inCollider == false)
        {
         
            plant1_NPC.SetActive(true);
            plant2_NPC.SetActive(true);
            codero_NPC.SetActive(true);
            floatingBubble.SetActive(false);
            spinch.all.SetActive(false);
            GetComponent<Buttoninteractions>().enabled = false;
        }

    if (text >= dialog)
    {
        floatingBubble.SetActive(false);
    }


    switch (text) // the main text blocks of the chatting stuff 
    {
        case 1: // This is the main talking points for the character. To edit this stuff go to the inventory in the inspect menu titled written dialog
            talking.text = (writtenDialog[0]);
            advance = true;
            spinch.happy.SetActive(true);
            spinch.neutral.SetActive(false);
            cretura.nervous.SetActive(true);
            cretura.neutral.SetActive(false);

            break;

        case 2:
            talking.text = (writtenDialog[w]);

            while (advance == true)
            {
                q++;
                advance = false;
            }

            ButtonActivate();

            choice = true;

            option1txt.text = (dialogOptions1[q]);
            option2txt.text = (dialogOptions2[q]);

            if (Buttoninteractions.option1clicked == true)
            {
                ButtonDeactiveate();
                text++;

            }

            else if (Buttoninteractions.option2clicked == true)
            {
                ButtonDeactiveate();
                text = 5; // Where you want the second option to begin from (this can also be used for if both options supply diffrent information) 
                w = 2; // Where in the dialog inventory to go from
            }

            break;


        case 3:
            talking.text = (writtenDialog[w]);
                
                advance = true;
                

                break;
        case 4:
                text = 6;
                w = 3;
                advance = true;
                break;
        case 5:
            talking.text = (writtenDialog[w]);
            advance = true;



            break;

        case 6:
            talking.text = (writtenDialog[w]);
            advance = true;
                spinch.neutral.SetActive(true);
                spinch.happy.SetActive(false);
                cretura.neutral.SetActive(true);
                cretura.nervous.SetActive(false);
            break;

        case 7:
            talking.text = (writtenDialog[w]);
            advance = true;
                spinch.happy.SetActive(true);
                spinch.neutral.SetActive(false);

            break;

            case 8:
                talking.text = (writtenDialog[w]);
                advance = true;
                spinch.neutral.SetActive(true);
                spinch.happy.SetActive(false);
                cretura.shock.SetActive(true);
                cretura.neutral.SetActive(false);
                break;




            case 9:
            talking.text = (writtenDialog[w]);
              
                while (advance == true)
                {
                    q++;
                    advance = false;
                }

                ButtonActivate();

                choice = true;

                option1txt.text = (dialogOptions1[q]);
                option2txt.text = (dialogOptions2[q]);

                if (Buttoninteractions.option1clicked == true)
                {
                    ButtonDeactiveate();
                    text = 10; // Where you want the second option to begin from (this can also be used for if both options supply diffrent information) 
                    w = 6; // Where in the dialog inventory to go from   //might be w9 instead 
                }

                else if (Buttoninteractions.option2clicked == true)
                {
                    ButtonDeactiveate();
                    text = 12;
                    w = 8;
                }




                break;

        case 10:
            talking.text = (writtenDialog[w]);
            advance = true;
            spinch.shock.SetActive(true);
            spinch.neutral.SetActive(false);

            break;

        case 11:
            talking.text = (writtenDialog[w]);
            advance = true;
            spinch.happy.SetActive(true);
            spinch.shock.SetActive(false);

            break;

        case 12:
            talking.text = (writtenDialog[w]);
            advance = true;
                spinch.happy.SetActive(true);
                spinch.shock.SetActive(false); //this might be needed idk hopefully
            break;

            //players look around for plants, which are on different scripts :)



    }
}




void EnterInteract()// for when the player enters, exits and advances dialog
{

    if (Input.GetButtonDown("Interact")) // when the player presses the interact button, then the quest will be given via an on screen UI text speech 
    {
        floatingBubble.SetActive(false);
        inTextBox = true;
        textBox.gameObject.SetActive(true);
    }

    if (Input.GetButtonDown("Submit") && inTextBox == true && choice == false && text < dialog)//sets it to false when they press enter and progresses the step number
    {
        text++;
        w++;
    }

    else if (Input.GetButtonDown("Submit") && text >= dialog)
    {
        inTextBox = false;
        textBox.gameObject.SetActive(false);
        Buttoninteractions.OptionOne.gameObject.SetActive(false);
        Buttoninteractions.OptionTwo.gameObject.SetActive(false);
    }

}

void ButtonActivate()// shows the player the button options 
{
    Buttoninteractions.OptionOne.gameObject.SetActive(true);
    Buttoninteractions.OptionTwo.gameObject.SetActive(true);
    talking.gameObject.SetActive(false);
}

void ButtonDeactiveate()// hides the button options from the player
{ 
    Buttoninteractions.option1clicked = false;
    Buttoninteractions.option2clicked = false;
    choice = false;
        Debug.Log("DEACTIVED BUTTON UGH");
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
    inTextBox = false;

    if (!(text >= dialog))
    {
        floatingBubble.SetActive(true);
    }

    textBox.gameObject.SetActive(false);
    Buttoninteractions.OptionOne.gameObject.SetActive(false);
    Buttoninteractions.OptionTwo.gameObject.SetActive(false);
}

    // Code written by Maxolotl (Jayden Cassar) 
    /*
        ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠠⠔⠒⠂⠀⠉⠀⠀⠉⠀⠒⠒⠤⢄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
    ⠀⠀⠀⠀⠀⠀⠀⠀⣠⠔⠊⠉⠀⠀⠀⠀⣀⣀⣀⣀⣀⣀⣀⣀⡀⠀⠀⠀⠑⠢⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
    ⠀⠀⠀⠀⠀⢀⠔⠉⠀⠀⢀⡠⠔⢊⣉⣉⣀⠤⠤⠤⠠⠄⣀⡀⠉⠉⠙⠋⠢⢄⡈⠑⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
    ⠀⠀⠀⢠⠞⠁⠀⠀⠀⠀⠫⠔⠊⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠒⠤⡀⠀⠀⠀⠈⠒⢄⠱⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
    ⠀⠀⡰⠁⠀⠀⠀⠀⠀⠀⣀⣀⠀⠤⠤⠀⠒⠒⠒⠒⠢⠤⠤⢀⣀⠀⠈⢆⠀⠀⠀⠀⠀⠉⠊⢢⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
    ⠀⢰⠁⠀⢀⡠⠤⠒⠊⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠑⠦⣣⠀⠀⠀⠀⠀⠀⠀⢣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
    ⠀⠈⠒⠊⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⡄⠀⠀⠀⠀⠀⠀⠀⢡⠀⠀⠀⠀⠀⠀⠀⠀⠀
    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⢄⡀⠀⠀⣀⣼⠀⠀⠀⠀⠀⠀⠀⠀⠀⢣⠀⠀⠀⠀⠀⠀⠀⠀
    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡤⠀⠑⠊⠉⢠⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢢⡀⠀⠀⠀⠀⠀⠀
    ⠀⠀⣠⠖⠢⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⡁⢀⠀⠀⡴⣾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠑⢄⠀⠀⠀⠀⠀
    ⠀⠀⡧⠀⠀⠈⢆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠆⡠⡧⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠈⢢⡤⠒⠲⡀
    ⠀⠀⢧⠀⠀⠀⠀⠣⡀⠀⠀⠀⠀⢀⣀⣀⣀⣀⣀⣀⣀⣀⣀⢀⠜⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡟⡢⠀⠀⠀⠠⡞⠁
    ⠀⠀⠘⢇⠀⠀⠀⠀⠈⠢⣀⠤⠊⠁⠀⠀⠀⠀⠀⠀⠀⠀⠉⠁⠒⠭⣒⠤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡜⠠⡁⠀⡼⠦⣀⠔⠀
    ⡜⡁⠉⠢⡑⢄⡀⠀⢀⠔⠁⠀⢠⣾⣿⣶⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠑⢎⠢⡀⠀⠀⠀⠀⠀⢀⠜⠀⠀⢈⡉⠀⠀⠀⠀⠀
    ⢧⠇⠀⠀⠈⠓⠽⣶⠏⠀⠀⠀⠸⢿⣿⠟⠁⠀⠀⠀⠀⠀⠀⣴⣿⣿⣧⠀⠀⠱⡘⡄⠀⠀⣀⣴⠯⠒⠒⠉⠁⠈⢣⠀⠀⠀⠀
    ⠈⠳⢄⣀⠀⠀⠀⡎⢀⠔⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⠿⠿⠟⠀⠀⠀⠸⡉⠉⠉⠀⠀⠀⠀⠀⠀⠀⢀⡜⠀⠀⠀⠀
    ⠀⡠⠤⠤⠭⠭⢴⡇⠘⣄⠘⠒⠒⠒⣉⣉⣉⣉⡉⠑⠒⠤⡀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⣀⡴⠊⠀⠀⠀⠀⠀
    ⠀⣇⠀⠀⠀⠀⠀⢇⠀⠈⠁⠉⠉⠉⠀⠀⠀⠀⠈⠉⠑⠢⣌⠓⠤⡀⠀⡘⠱⡄⠀⡿⠷⠶⠶⠶⠶⠿⠭⢅⣀⠀⠀⠀⠀⠀⠀
    ⠀⠈⠑⠒⠒⠒⠒⠉⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠑⠢⣌⣉⣀⠜⠀⢰⡁⠀⠀⠀⠀⠀⠀⠀⠀⡸⠀⠀⠀⠀⠀⠀
    ⠀⡠⠤⣀⠀⣠⠔⠊⢄⠳⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡴⠛⠫⢗⡢⠤⠤⠤⠤⠤⠚⠁⠀⠀⠀⠀⠀⠀
    ⠀⣣⡀⠈⠋⠀⠀⢀⣈⠦⠒⠑⠢⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡠⠄⢻⣆⠀⠀⠀⠈⠒⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
    ⢸⡁⣀⡀⠀⡖⠊⠁⠀⠀⠀⠀⠀⠀⠈⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠱⡀⠒⠀⢇⠑⠢⠤⠤⠤⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
    ⠀⠉⠘⢄⡠⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢱⡀⠀⠈⠦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡴⠋⠀⡀⠀⣀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠒⠚⢄⣀⡟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
    */





}