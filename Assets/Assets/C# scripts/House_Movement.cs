using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_Movement : MonoBehaviour
{

    [HideInInspector] public bool cordydate;
	public PhoneMenu phoneMenu;
    public Spinch_intro interactWith;
    public Spinch_to_cordi spc;
    public Spinch_to_cordi_2 spc2;
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

        if (interactWith.inTextBox == false && spc.inTextBox == false && spc2.inTextBox == false && phoneMenu.inPhone == false)
        {
            rb.velocity = new Vector3(
                Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                rb.velocity.y,
                Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f)
            );
        }

    }
}

