using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyController : MonoBehaviour {

	public int initialDirection = 1;
	public float initialVelocity = 10f;
	private float velocity = 0f;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.freezeRotation = true;
		velocity = initialVelocity * initialDirection;
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector3 (0f, rb.velocity.y, velocity);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Bound")
		{
			velocity = -velocity;
			transform.Rotate(new Vector3 (0, 180, 0));
		}	
	}

}
