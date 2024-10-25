using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Cordero_main : MonoBehaviour
{
    [Header("sprites")]
    public Cretura cretura;
    public Cordero cordero;

    [HideInInspector] public bool inTextBox = false;
    private bool inCollider = false;
    private bool choice = false;
    private bool advance = false;

    [Header("Dialog")]
    [SerializeField] List<string> writtenDialog;
    [SerializeField] List<string> dialogOptions1;
    [SerializeField] List<string> dialogOptions2;

    [Header("npcs")]
    [SerializeField] private GameObject Test_NPC_spinch;
    [SerializeField] private GameObject front_NPC;
    [SerializeField] private GameObject plant1_NPC;
    [SerializeField] private GameObject plant2_NPC;
    [SerializeField] private GameObject codero_NPC;

    [Header("OtherItems")]
    public GameObject textBox;
    public TextMeshProUGUI talking;
    public TextMeshProUGUI option1txt;
    public TextMeshProUGUI option2txt;
    public Buttoninteractions Buttoninteractions;
    public GameObject floatingBubble;

    private int text = 1;
    private int w = 0;
    private int q = 0;

    [SerializeField] private int dialog = 53; //Make sure this matches the amount of cases


    void Update()
    {
        if (inCollider == true)
        {
            EnterInteract();
            front_NPC.SetActive(false);
            Test_NPC_spinch.SetActive(false);
            plant2_NPC.SetActive(false);
            plant1_NPC.SetActive(false);
            cordero.all.SetActive(true);
            if(inTextBox == false)

            GetComponent<Buttoninteractions>().enabled = true;
            {
                floatingBubble.SetActive(true);
            }
        }
        else if (inCollider == false)
        {
            front_NPC.SetActive(true);
            Test_NPC_spinch.SetActive(true);
            plant2_NPC.SetActive(true);
            plant1_NPC.SetActive(true);
            floatingBubble.SetActive(false);
            cordero.all.SetActive(false);

            GetComponent<Buttoninteractions>().enabled = false;
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
                cretura.neutral.SetActive(true);
                cretura.neutral.SetActive(false);
                cordero.happy.SetActive(true);
                cordero.neutral.SetActive(false);

                break;

            case 2:
                talking.text = (writtenDialog[w]);
                advance = true;

                break;
            case 3:


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
                    text = 6; // Where you want the second option to begin from (this can also be used for if both options supply diffrent information) 
                    w = 3; // Where in the dialog inventory to go from
                }

                break;

            case 4: // This is the button dialogs. to change the text add your option into the coresponding dialog options inventory in the inspect menu (1 for opt 1, 2 for opt 2) 
                talking.text = (writtenDialog[w]);



                advance = true;


                break;
            case 5:
                text = 7;
                w = 4;
                advance = true;
                break;
            case 6:
                talking.text = (writtenDialog[w]);

                cretura.shock.SetActive(true); //To change a character's expression use the format NAME.EMOTION.Setactive(true) for the one you want to be active
                cretura.neutral.SetActive(false); //Use NAME.EMOTION.setactive(false) for the one you want to deactivate
                advance = true;


                break;

            case 7:
                talking.text = (writtenDialog[w]);
                cretura.blush.SetActive(true);
                cretura.shock.SetActive(false);
                cordero.happy.SetActive(false);
                cordero.shock.SetActive(true);
                advance = true;

                break;

            case 8:
                talking.text = (writtenDialog[w]);
                cordero.happy.SetActive(true);
                cordero.shock.SetActive(false);
                advance = true;
                break;

            case 9:

                talking.text = (writtenDialog[w]);



                cretura.nervous.SetActive(true);
                cretura.blush.SetActive(false);

                advance = true;


                break;
            case 10:
                talking.text = (writtenDialog[w]);
                advance = true;
                break;

            case 11:

                talking.text = (writtenDialog[w]);

                cordero.neutral.SetActive(true);
                cordero.happy.SetActive(false);
                cretura.neutral.SetActive(true);
                cretura.nervous.SetActive(false);
                advance = true;
                break;

            // add new stuff here
            case 12:
                talking.text = (writtenDialog[w]);

                cretura.nervous.SetActive(true);
                cretura.neutral.SetActive(false);
                advance = true;
                break;

            case 13:

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
                    text = 14; // Where you want the second option to begin from (this can also be used for if both options supply diffrent information) 
                    w = 12; // Where in the dialog inventory to go from
                }


                break;

            case 14:
                talking.text = (writtenDialog[w]);

                cordero.disappointed.SetActive(true);
                cordero.neutral.SetActive(false);
                advance = true;
                break;

            case 15:
                talking.text = (writtenDialog[w]);


                cretura.blush.SetActive(true);
                cretura.nervous.SetActive(false);
                advance = true;

                break;

            case 16:
                text = 17;
                w = 14;
                break;

            case 17:
                talking.text = (writtenDialog[w]);

                cordero.blush.SetActive(true);
                cordero.neutral.SetActive(false);
                advance = true;
                break;

            case 18:
                talking.text = (writtenDialog[w]);
                advance = true;
                break;

            case 19:
                talking.text = (writtenDialog[w]);

                cretura.neutral.SetActive(true);
                cretura.blush.SetActive(false);

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
                    text = 28; // Where you want the second option to begin from (this can also be used for if both options supply diffrent information) 
                    w = 25; // Where in the dialog inventory to go from
                }

                break;

            case 20:
                talking.text = (writtenDialog[w]);

                cordero.confused.SetActive(true);
                cordero.blush.SetActive(false);
                cordero.disappointed.SetActive(false);
                advance = true;
                break;

            case 21:
                talking.text = (writtenDialog[w]);

                cretura.nervous.SetActive(true);
                cretura.neutral.SetActive(false);
                cretura.sad.SetActive(false);
                advance = true;
                break;

            case 22:
                talking.text = (writtenDialog[w]);
                advance = true;
                break;

            case 23:
                talking.text = (writtenDialog[w]);

                cretura.neutral.SetActive(true);
                cretura.nervous.SetActive(false);
                advance = true;
                break;

            case 24:
                talking.text = (writtenDialog[w]);

                //cretura eats the apple sprite goes here
                advance = true;
                break;

            case 25:
                talking.text = (writtenDialog[w]);

                //here as well for the above
                advance = true;
                break;

            case 26:
                talking.text = (writtenDialog[w]);

                //remove the unique sprite
                cretura.sad.SetActive(true);
                cretura.neutral.SetActive(false);
                advance = true;
                break;

            case 27:
                talking.text = (writtenDialog[w]);

                cordero.happy.SetActive(true);
                cordero.confused.SetActive(false);
                advance = true;
                break;

            case 28:
                talking.text = (writtenDialog[w]);
                cretura.neutral.SetActive(true);
                cretura.sad.SetActive(false);
                cordero.blush.SetActive(true);
                cordero.happy.SetActive(false);
                advance = true;
                break;

            case 29:
                text = 30;
                w = 26;
                break;



            case 30:
                talking.text = (writtenDialog[w]);

                cordero.neutral.SetActive(true);
                cordero.blush.SetActive(false);
                cretura.blush.SetActive(true);
                cretura.neutral.SetActive(false);
               
                advance = true;
                break;


            case 31:
                talking.text = (writtenDialog[w]);

                cretura.blush.SetActive(false);
                cretura.nervous.SetActive(true);

                advance = true;
                break;


            case 32:
                talking.text = (writtenDialog[w]);

                cordero.sad.SetActive(true);
                cordero.confused.SetActive(false);
                advance = true;
                break;

            case 33:
                talking.text = (writtenDialog[w]);

                cordero.neutral.SetActive(true);
                cordero.sad.SetActive(false);
                cretura.blush.SetActive(true);
                cretura.nervous.SetActive(false);
                advance = true;
                break;

            case 34:
                talking.text = (writtenDialog[w]);
                cordero.neutral.SetActive(true);
                cordero.blush.SetActive(false);
                advance = true;


                break;



            case 35:
                talking.text = (writtenDialog[w]);
                cretura.nervous.SetActive(true);
                cretura.blush.SetActive(false);

                advance = true;
                break;

            case 36:
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
                    text++;
                }


                break;

            case 37:
                talking.text = (writtenDialog[w]);
                cordero.blush.SetActive(true);
                cordero.neutral.SetActive(false);
                advance = true;



                break;

            case 38:
                talking.text = (writtenDialog[w]);

                advance = true;
                break;

            case 39:
                talking.text = (writtenDialog[w]);
                advance = true;
                cretura.nervous.SetActive(true);
                cretura.neutral.SetActive(false);
                break;

            case 40:
                talking.text = (writtenDialog[w]);

                cordero.confused.SetActive(true);
                cordero.neutral.SetActive(false);
                advance = true;
                break;

            case 41:
                talking.text = (writtenDialog[w]);

                advance = true;
                break;

            case 42:
                talking.text = (writtenDialog[w]);
                cordero.blush.SetActive(true);
                cordero.confused.SetActive(false);

                advance = true;
                break;

            case 43:
                talking.text = (writtenDialog[w]);

                advance = true;
                break;

            case 44:
                talking.text = (writtenDialog[w]);
                cordero.happy.SetActive(true);
                cordero.blush.SetActive(false);
                
                advance = true;
                break;

            case 45:
                talking.text = (writtenDialog[w]);

                cordero.neutral.SetActive(true);
                cordero.happy.SetActive(false);

                advance = true;
                break;

          
            case 46:
                talking.text = (writtenDialog[w]);
              
                cordero.happy.SetActive(true);
                cordero.neutral.SetActive(false);
                advance = true;

                break;
            case 47:
                talking.text = (writtenDialog[w]);
               
                advance = true;
                break;

            case 48:
                talking.text = (writtenDialog[w]);

                advance = true;
                break;

            case 49:
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
                    text++;
                }



                break;

            case 50:
                talking.text = (writtenDialog[w]);
                cordero.confused.SetActive(true);
                cordero.happy.SetActive(false);

                //cretura frames should deactivate so we can't see cretura in the dialog menu

                advance = true;
                break;

            case 51:
                talking.text = (writtenDialog[w]);

                advance = true;
                break;

            case 52:
                talking.text = (writtenDialog[w]);

                advance = true;

                break;
            case 53:
                talking.text = (writtenDialog[w]);
                

                advance = true;

                SceneManager.LoadScene("House");
                break;

             //add a transition to black, then you return home



            default:
                Debug.LogError("out of case area");

                break;
               
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


