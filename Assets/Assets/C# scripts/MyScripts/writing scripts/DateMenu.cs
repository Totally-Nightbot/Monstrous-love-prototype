using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateMenu : MonoBehaviour
{
    public House_Movement movement;
    public GameObject spinchobj;
    public GameObject DateUI;
    public Button cordial;
    public Button dordor;
    private void Start()
    {
        Button op1 = cordial.GetComponent<Button>();
        op1.onClick.AddListener(PickCordial);

        Button op2 = dordor.GetComponent<Button>();
        op2.onClick.AddListener(PickDorDor);
    }

    void PickCordial()
    {
       var scordi = spinchobj.GetComponent<Spinch_intro>();
       var scordi2 = spinchobj.GetComponent<Spinch_to_cordi>();

        scordi.inTextBox = false;
        scordi.enabled = false;
        scordi2.enabled = true;
        DateUI.gameObject.SetActive(false);

        movement.cordydate = true;
    }

    void PickDorDor()
    {
        Debug.Log("nuh uh pick cordial");
        movement.cordydate = false;
    }


}

