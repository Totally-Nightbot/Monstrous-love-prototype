using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leaving : MonoBehaviour
{
    public Spinch_to_cordi_2 spinch_To_Cordi_2;
    public GameObject bg;

    private void OnTriggerEnter(Collider other)
    {
        if (spinch_To_Cordi_2.leave == true)
        {
            bg.SetActive(true);
            Invoke("MoveScene", 2.0f);
        }
    }

    void MoveScene()
    {
        SceneManager.LoadScene("Resturant final scene");
    }

}
