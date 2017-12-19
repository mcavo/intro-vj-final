using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterController : MonoBehaviour {

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool onGround;
	private Rigidbody rb;
	private int direction = 1;
	private int blockCounter;
	private int BLOCKED_GAME_MAX = 10;
	private float EPSILON = 0.001f;

	private Vector3 lastPosition = Vector3.right;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.freezeRotation = true;
		blockCounter = 0;
		if (Physics.gravity.y > 0) {
			Physics.gravity = -Physics.gravity;
		}

	}

	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(transform.position.y - lastPosition.y) <= EPSILON && Mathf.Abs(transform.position.z - lastPosition.z) <= EPSILON) {
			blockCounter += 1;
			if (blockCounter == BLOCKED_GAME_MAX) {
				GameManager.instance.GameOver ();
			}
		} else {
			blockCounter = 0;
		}
		rb.velocity = new Vector3 (0f, rb.velocity.y, 7f);
		onGround = Physics.CheckSphere (groundCheck.position, groundCheckRadius, whatIsGround);

		if (onGround && Input.GetMouseButtonDown (0)) {
			rb.velocity = new Vector3 (0f, direction*15f, rb.velocity.z);
		}
		lastPosition = transform.position;
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "ReverseGravity")
		{
			Physics.gravity = -Physics.gravity;
			transform.Rotate (new Vector3 (0, 0, 180));
			direction = -direction;
		}
		else if (col.tag == "Portal")
		{
			transform.position = col.gameObject.GetComponent<PortalController> ().newPosition.transform.position;
		}
		else if (col.tag == "DeadZone" || col.tag == "Enemy")
		{
			GameManager.instance.GameOver ();
		}
		else if (col.tag == "Goal")
		{
			GameManager.instance.WinGame ();
		}
		else if (col.tag == "BounceBoost")
		{
			rb.velocity = new Vector3 (0f, 25f, rb.velocity.z);
		}
	}

}
