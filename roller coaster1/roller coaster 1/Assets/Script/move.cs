using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
	 float speed=0;
	//public GameObject track;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.position+=new Vector3(speed,0,0);
		//trackfollowing(coaster1);
		//OnCollisionEnter;
	}
	void OnCollisionEnter(Collision col){
		if(col.gameObject.name=="Cube") {
			speed -= 0.05f;
		}
		if (col.gameObject.tag == "trackx") {
			speed -= 0.05f;
		}
	}
	/*void OnTriggerEnter(Collider empty){
		if (empty.gameObject.tag == "obstacle") {
			//speed -= 0.2f;
		}
	}*/
}
