﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spinch_to_cordi_3 : MonoBehaviour
{
    public Cretura cretura;
public Spinch spinch;

[HideInInspector] public bool inTextBox = false;
private bool inCollider = false;
private bool choice = false;
private bool advance = false;

public List<string> writtenDialog;
public List<string> dialogOptions1;
public List<string> dialogOptions2;

public GameObject textBox;
public TextMeshProUGUI talking;
public TextMeshProUGUI option1txt;
public TextMeshProUGUI option2txt;
public Buttoninteractions Buttoninteractions;
public GameObject floatingBubble;

private int text = 1;
private int w = 0;
private int q = 0;

[SerializeField] private int dialog = 0; //Make sure this matches the amount of cases


void Update()
{

    if (inCollider == true)
    {
        EnterInteract();

    }

    if (text >= dialog)
    {
        floatingBubble.SetActive(false);
    }


    switch (text) // the main text blocks of the chatting stuff 
    {
        case 1: // This is the main talking points for the character. To edit this stuff go to the inventory in the inspect menu titled written dialog
            talking.text = (writtenDialog[w]);
            advance = true;
            spinch.happy.SetActive(true);
            spinch.neutral.SetActive(true);


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
                text = 4; // Where you want the second option to begin from (this can also be used for if both options supply diffrent information) 
                w = 3; // Where in the dialog inventory to go from
            }

            break;


        case 3:
            talking.text = (writtenDialog[w]);
            advance = true;
                text = 5;
                w = 4 ;

            break;

        case 4:
            talking.text = (writtenDialog[w]);
            advance = true;



            break;

        case 5:
            talking.text = (writtenDialog[w]);
            advance = true;
        
            break;

        case 6:
            talking.text = (writtenDialog[w]);
            advance = true;
                spinch.happy.SetActive(true);
                spinch.neutral.SetActive(false);

            break;

        case 7:
            talking.text = (writtenDialog[w]);
            advance = true;
            

            break;




        case 9:
            talking.text = (writtenDialog[w]);
            advance = true;

           

            break;

        case 10:
            talking.text = (writtenDialog[w]);
            advance = true;


            break;

        case 11:
            talking.text = (writtenDialog[w]);
            advance = true;


            break;

        case 12:
            talking.text = (writtenDialog[w]);
            advance = true;
           
            break;

        case 13:
            talking.text = (writtenDialog[w]);
            advance = true;
           

            break;

        case 14:
            talking.text = (writtenDialog[w]);
            advance = true;
            spinch.happy.SetActive(false);
            spinch.neutral.SetActive(true);

            break;

        case 15:
            talking.text = (writtenDialog[w]);
            advance = true;


            spinch.happy.SetActive(true);
            spinch.neutral.SetActive(false);
            break;

            //transition to resturant



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

    if (Input.GetButtonDown("Submit") && choice == false && text < dialog)//sets it to false when they press enter and progresses the step number
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