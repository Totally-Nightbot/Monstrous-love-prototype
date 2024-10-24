using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant_Movement : MonoBehaviour
{
    public PhoneMenu phoneMenu;
    public Plant_1_cordi plc;
    public Plant_2_cordi plc2;
    public Spinch_to_cordi_3 spc3;
    public Cordero_main cm;
    public float walkSpeed = 5f;



    float maxSpeed = 10f;
    float curSpeed;

    float sprintSpeed;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        curSpeed = walkSpeed;
        maxSpeed = curSpeed;

        // the movement magic

        if (plc2.inTextBox == false && plc.inTextBox == false && cm.inTextBox == false && spc3.inTextBox == false && phoneMenu.inPhone == false)
        {
            rb.velocity = new Vector3(
                Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                rb.velocity.y,
                Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f)
            );
        }

    }
}

