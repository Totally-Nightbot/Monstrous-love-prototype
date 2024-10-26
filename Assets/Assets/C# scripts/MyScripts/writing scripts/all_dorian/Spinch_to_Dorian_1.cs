using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spinch_to_Dorian_1 : MonoBehaviour

    ///rn this is placeholder, will edit asap to the right cases .... this is in the home still, transition to arcade
{
    [Header("sprites")]
    public Cretura cretura;
    public Spinch spinch;

    [HideInInspector] public bool inTextBox = false;
    private bool inCollider = false;
    private bool choice = false;
    private bool advance = false;

    [Header("Dialog")]
    public List<string> writtenDialog;
    public List<string> dialogOptions1;
    public List<string> dialogOptions2;

    [Header("OtherItems")]
    public GameObject dateUI;
    public GameObject textBox;
    public TextMeshProUGUI talking;
    public TextMeshProUGUI option1txt;
    public TextMeshProUGUI option2txt;
    public Buttoninteractions Buttoninteractions;
    public GameObject floatingBubble;

    [SerializeField] private int text = 1;
  private int w = 0;
  private int q = 0;

   [SerializeField] private int dialog = 4; //Make sure this matches the amount of cases

    
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

                cretura.blush.SetActive(true);
                cretura.neutral.SetActive(false);

                advance = true;

               
                break;

            case 2:
                talking.text = (writtenDialog[w]);
               
                
                advance = true; // needs to be placed in the case before a question
               
                break;
               

            case 3:
                talking.text = (writtenDialog[w]);
               
                advance = true; // needs to be placed in the case before a question
                break;

            case 4: // This is the button dialogs. to change the text add your option into the coresponding dialog options inventory in the inspect menu (1 for opt 1, 2 for opt 2) 
                talking.text = (writtenDialog[w]);

               
                advance = true;
              

                break;

            
            default:
                Debug.LogError("out of case area");

                break;
                // here is where the option for either cordero or dorian should go--> I'd assume this script ends here, then 
                ///////
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

        textoff();
    }

    void textoff()
    {
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


