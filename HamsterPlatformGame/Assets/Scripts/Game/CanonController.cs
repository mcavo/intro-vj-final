using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour {

	public GameObject bullet;
	public Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		StartCoroutine (ShootRoutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator ShootRoutine()
	{
		while(true) {
			Instantiate (bullet, initialPosition, Quaternion.Euler(0, 0, 0));
			yield return new WaitForSeconds (2.0f);
		}
	}

}
