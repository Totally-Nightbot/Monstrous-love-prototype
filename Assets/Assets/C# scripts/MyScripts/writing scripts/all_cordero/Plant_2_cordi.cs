using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Plant_2_cordi : MonoBehaviour
{
    public Cretura cretura;
    public Spinch spinch; //plant sprite go here?

    [HideInInspector] public bool inTextBox = false;
    private bool inCollider = false;
    private bool choice = false;
    private bool advance = false;

    [SerializeField] List<string> writtenDialog;
    [SerializeField] List<string> dialogOptions1;
    [SerializeField] List<string> dialogOptions2;

    [Header("npcs")]
    [SerializeField] private GameObject Test_NPC_spinch;
    public GameObject plant;
    [SerializeField] private GameObject plant1_NPC;
    [SerializeField] private GameObject plant2_NPC;
    [SerializeField] private GameObject codero_NPC;

    public GameObject textBox;
    public TextMeshProUGUI talking;
    public TextMeshProUGUI option1txt;
    public TextMeshProUGUI option2txt;
    public Buttoninteractions Buttoninteractions;
    public GameObject floatingBubble;

    private int text = 1;
    private int w = 0;
    private int q = 0;

    [SerializeField] private int dialog = 16; //Make sure this matches the amount of cases


    void Update()
    {

        if (inCollider == true)
        {
            EnterInteract();
            Test_NPC_spinch.SetActive(false);
            plant1_NPC.SetActive(false);
            codero_NPC.SetActive(false);

            GetComponent<Buttoninteractions>().enabled = true;

            if (inTextBox == false)
            {
                floatingBubble.SetActive(true);
            }
        }
        else if (inCollider == false)
        {
            Test_NPC_spinch.SetActive(true);
            plant1_NPC.SetActive(true);
            codero_NPC.SetActive(true);
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
                cretura.neutral.SetActive(true);
                advance = true;


                break;

            case 2:
                talking.text = (writtenDialog[w]);
                advance = true;
                cretura.blush.SetActive(true);
                cretura.neutral.SetActive(false);
                break;


            case 3:
                talking.text = (writtenDialog[w]);
                advance = true;


                break;

            case 4:
                talking.text = (writtenDialog[w]);
                advance = true;
                cretura.neutral.SetActive(true);
                cretura.blush.SetActive(false);


                break;

            case 5:
                talking.text = (writtenDialog[w]);
                advance = true;
                
                break;

            case 6:
                talking.text = (writtenDialog[w]);
                advance = true;


                break;

            case 7:
                talking.text = (writtenDialog[w]);
                advance = true;
                cretura.shock.SetActive(true);
                cretura.neutral.SetActive(false);

                break;




            case 8:
                talking.text = (writtenDialog[w]);
                advance = true;
                cretura.nervous.SetActive(true);
                cretura.shock.SetActive(false);

                break;

            case 9:
                talking.text = (writtenDialog[w]);
                advance = true;


                break;

            case 10:
                talking.text = (writtenDialog[w]);
                advance = true;
                cretura.sad.SetActive(true);
                cretura.nervous.SetActive(false);

                break;

            case 11:
                talking.text = (writtenDialog[w]);
                advance = true;

                break;

            case 12:
                talking.text = (writtenDialog[w]);
                advance = true;
                cretura.shock.SetActive(true);
                cretura.sad.SetActive(false);
                break;

            case 13:
                talking.text = (writtenDialog[w]);
                advance = true;
                cretura.nervous.SetActive(true);
                cretura.shock.SetActive(false);
                break;

            case 14:
                talking.text = (writtenDialog[w]);
                advance = true;

                break;

            case 15:
                talking.text = (writtenDialog[w]);
                advance = true;
                cretura.neutral.SetActive(true);
                cretura.nervous.SetActive(false);
                break;

            case 16:
                talking.text = (writtenDialog[w]);
                advance = true;

                break;

          

                //players look around for plant number 2, which is on a different script :)



        }
    }




    void EnterInteract()// for when the player enters, exits and advances dialog
    {

        if (Input.GetButtonDown("Interact")) // when the player presses the interact button, then the quest will be given via an on screen UI text speech 
        {
            plant.SetActive(true);
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
            plant.SetActive(false);
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