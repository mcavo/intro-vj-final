using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public Vector3 velocity;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = velocity;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Bound")
		{
			Destroy (gameObject);
		}	
	}
}
