using UnityEngine;
using System.Collections;

public class scrPlayerControls : MonoBehaviour {

	private Vector3 acc;
	public int jumps = 2;
	public float moveSpeed;
	public float jumpSpeed;
	public float damping;
	public CharacterController charCtrl;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float x = Input.GetAxisRaw("Horizontal");
		float z = Input.GetAxisRaw("Vertical");
		float jump = Input.GetAxis("Jump");

		if (charCtrl.isGrounded) {
			jumps = 2;
		}


		if (Input.GetButtonDown("Jump"))
		{
			jumps = jumps - 1;
		}

		transform.Rotate(0, x, 0);

		Vector3 moveDirection = new Vector3(x,0,z);
		moveDirection.Normalize ();
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= moveSpeed;

		acc.x = Mathf.Lerp (acc.x, moveDirection.x, damping);
		acc.z = Mathf.Lerp (acc.z, moveDirection.z, damping);


		acc.y = charCtrl.isGrounded ? -2f : acc.y - 15f * Time.deltaTime;
		acc.y += Input.GetButtonDown("Jump") && jumps >= 0 ? jumpSpeed : 0;
		damping = charCtrl.isGrounded ? 2f : 0.1f;


		charCtrl.Move(acc * Time.deltaTime);
	}
}
