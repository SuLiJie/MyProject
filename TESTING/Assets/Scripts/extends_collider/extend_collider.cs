using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extend_collider : collider {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnCollisionStay(Collision game){
		if (game.gameObject.name == "Plane")
			Debug.Log ("sex");
	}
}

