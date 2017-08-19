using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_2 : NPC {
	void Start () {
		order_check (gameObject);
	}

	// Update is called once per frame
	void Update () {
		if (mangement.game_state != 2) {
			//if (Input.GetKeyDown (KeyCode.F1))
			//Destroy (gameObject);
			order_check (gameObject);
			keepTrainOnTrack ();
			forward (now_Speed);
			front_distance (gameObject);
			Debug.Log (gameObject.name + " ");
			AI (front_dis);
		}
	}
}
