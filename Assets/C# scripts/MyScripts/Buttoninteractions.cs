using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Buttoninteractions : MonoBehaviour
{
	public Button OptionOne;
	public Button OptionTwo;
    public bool option1clicked = false;
    public bool option2clicked = false;

    void Start()
    {
        Button op1 = OptionOne.GetComponent<Button>();
        op1.onClick.AddListener(OptionOneClicked);

        Button op2 = OptionTwo.GetComponent<Button>();
        op2.onClick.AddListener(OptionTwoClicked);
    }

    void OptionOneClicked()
	{
        Debug.Log("buttonclicked number 1");
        option1clicked = true;
	}

    void OptionTwoClicked()
    {
        Debug.Log("buttonclicked number 2");
        option2clicked = true;
    }

}
