using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Post_dressup : MonoBehaviour
{

    public GameObject mainUI;
    public GameObject minigameUI;
    public GameObject spinchobj;
    public House_Movement movement;
    public Button done;

    private void Start()
    {
        Button op1 = done.GetComponent<Button>();
        op1.onClick.AddListener(MoveOn);
    } 

    void MoveOn()
    {
        if (movement.cordydate == true)
        {
            var scordi = spinchobj.GetComponent<Spinch_to_cordi>();
            var scordi2 = spinchobj.GetComponent<Spinch_to_cordi_2>();

            scordi.inTextBox = false;
            scordi.enabled = false;
            scordi2.enabled = true;
            minigameUI.gameObject.SetActive(false);
            mainUI.gameObject.SetActive(true);
        }
        else if (movement.cordydate == false)
        {

        }
    }
}

