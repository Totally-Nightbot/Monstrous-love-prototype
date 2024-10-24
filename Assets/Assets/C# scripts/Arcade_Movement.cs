using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcade_Movement : MonoBehaviour
{
	public PhoneMenu phoneMenu;
		public InteractWith interactWith;
	public Spinch_to_Dorian_2 std2; //coincidence ik
	public Dorian_main dm;
	public dorian_plant1 dp1;
	public dorian_plant2 dp2;
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
			
			if (interactWith.inTextBox == false && phoneMenu.inPhone == false && std2 == false && dm == false && dp1 == false && dp2 == false)
		{
            rb.velocity = new Vector3(
                Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                rb.velocity.y,
                Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f)
            );
        }
			
		}
}
