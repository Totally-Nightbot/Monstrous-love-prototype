using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractWith1 : MonoBehaviour


{
    [Header("sprites")]
    public Cretura cretura;

    [HideInInspector] public bool inTextBox = false;
    private bool inCollider = false;
    private bool choice = false;
    private bool advance = false;

    [Header("npcs")]
    [SerializeField] private GameObject Test_NPC;
    [SerializeField] private GameObject Spinch_NPC;
    [SerializeField] private GameObject dorian_NPC;
    [SerializeField] private GameObject Plant_1_NPC;
    [SerializeField] private GameObject Plant_2_NPC;


    [Header("Dialog")]
    public List<string> writtenDialog;
    public List<string> dialogOptions1;
    public List<string> dialogOptions2;

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

   [SerializeField] private int dialog = 9; //Make sure this matches the amount of cases

    
    void Update()
    {


        if (inCollider == true)
        {
            EnterInteract();
            Test_NPC.SetActive(false);
            Spinch_NPC.SetActive(false);
            dorian_NPC.SetActive(false);
            Plant_1_NPC.SetActive(false);
            Plant_2_NPC.SetActive(false);

            GetComponent<Buttoninteractions>().enabled = true;

            if (inTextBox == false)
            {
                floatingBubble.SetActive(true);

            }
        }
        else if (inCollider == false)
        {
            Test_NPC.SetActive(true);
            Spinch_NPC.SetActive(true);
            dorian_NPC.SetActive(true);
            Plant_1_NPC.SetActive(true);
            Plant_2_NPC.SetActive(true);
            floatingBubble.SetActive(false);
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

                break;

            case 2:
                talking.text = (writtenDialog[w]);

                break;

            case 3:
                talking.text = (writtenDialog[w]);

                advance = true; // needs to be placed in the case before a question
                break;

            case 4: // This is the button dialogs. to change the text add your option into the coresponding dialog options inventory in the inspect menu (1 for opt 1, 2 for opt 2) 
                
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
                    w = 4; // Where in the dialog inventory to go from
                }

                break;

            case 5:

                talking.text = (writtenDialog[w]);
                cretura.shock.SetActive(true); //To change a character's expression use the format NAME.EMOTION.Setactive(true) for the one you want to be active
                cretura.neutral.SetActive(false); //Use NAME.EMOTION.setactive(false) for the one you want to deactivate
                break;

            case 6:
                talking.text = (writtenDialog[w]);
                break;

            case 7:
                talking.text = (writtenDialog[w]);

                advance = true; 
                break;

            case 8: 

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
                    cretura.nervous.SetActive(true);
                    cretura.shock.SetActive(false);
                    ButtonDeactiveate();
                    text++;
                }

                else if (Buttoninteractions.option2clicked == true)
                {
                    ButtonDeactiveate();
                    text = 9;
                    w = 6;
                }

                break;

            case 9:

                talking.text = (writtenDialog[w]);
                break;

                // add new stuff here

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

        if( !(text >= dialog))
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


