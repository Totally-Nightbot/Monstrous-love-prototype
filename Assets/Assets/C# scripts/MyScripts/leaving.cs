using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leaving : MonoBehaviour
{
    public Spinch_to_cordi_2 spinch_To_Cordi_2;
    private void OnTriggerEnter(Collider other)
    {
        if (spinch_To_Cordi_2.leave == true)
        {
            SceneManager.LoadScene("Resturant final scene");
        }
    }
}
