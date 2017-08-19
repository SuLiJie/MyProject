using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour {
	public GameObject cam1,cam2,player;
	// Use this for initialization
	void Awake(){
		cam1.SetActive (true);
		cam2.SetActive (false);
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 cameraMove=new Vector3(player.transform.position.x-2.49f,player.transform.position.y+0.25f,player.transform.position.z+3.37f);
		//cam1.transform.position = 
		//cam2.transform.position = 

		if (Input.GetKey ("z") == true) {
			cam1.SetActive (false);
			cam2.SetActive (true);
		} 
		else if (Input.GetKey ("x") == true) {
			cam1.SetActive (true);
			cam2.SetActive (false);
		}

	}
}
