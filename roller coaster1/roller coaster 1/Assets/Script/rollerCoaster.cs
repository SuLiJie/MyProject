using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollerCoaster : MonoBehaviour {
	public static float speed=-0.05f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "faster") {
			speed -= 0.05f;
		}
		/*else if (col.gameObject.tag == "obstacle") {
			speed += 0.05f;
		}*/
		else if (col.gameObject.tag == "rollercoaster_back" ) {
				Destroy (gameObject);
			Debug.Log ("test");
		}
	}

}
