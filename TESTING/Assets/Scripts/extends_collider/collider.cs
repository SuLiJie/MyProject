﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnCollisionEnter(Collision plane){
		if(plane.gameObject.name=="Plane")	
		Debug.Log ("fuckme");
	}
}
