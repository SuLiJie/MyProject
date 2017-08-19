using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : rollerCoaster {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += new Vector3 (rollerCoaster.speed, 0, 0);
		//gameObject.transform.Rotate+=new Vector3(0,0,rollerCoaster.speed);
		//print (rollerCoaster.speed);

		if (Input.GetKey ("a")) {
			speed -= 0.02f;
		}

		if (Input.GetKey ("s")) {
			speed += 0.02f;
		}

	}

}
