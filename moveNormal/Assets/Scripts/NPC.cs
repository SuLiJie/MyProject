using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : rollerCoaster {
	//GameObject train;
	float time;
	public static float Npc_hp=1;
	public float back_dis,front_dis;

	//--------------------抓距離-----------------------------

	public float speed_up(float speed){
		speed =speed+ 0.1f;
		Npc_hp -= 0.1f;
		return speed;
	}
	public float speed_down(float speed){
		speed =speed- 0.1f;
		return speed;
	}

	public void back_distance(GameObject obj){
		if (order != mangement.totalTrainCount) {
			back_dis = Vector3.Distance (obj.transform.position, manageScript [0].train [order + 1].transform.position);
		} else
			back_dis = 0;
	}
	public void front_distance(GameObject obj){
		
		if (order != 0&&mangement.orderStore [order - 1]!=null ) {
			GameObject frontObj =mangement.orderStore [order - 1];
			front_dis = Vector3.Distance (obj.transform.position,frontObj.transform.position);
		} else
			front_dis = 0;
	}
	public void AI(float distance){
		if (mangement.game_state != 0) {
            Debug.Log(gameObject.name+" "+now_Speed);
			if (distance < 4) 
				now_Speed -= 0.02f;
            if (distance < 2)
                now_Speed -= 0.05f;
            if (distance < 1)
                now_Speed -= 0.1f;
            if (now_Speed < 0.05)
                now_Speed += 0.05f;
            //if (distance >= 4) 
				//now_Speed += Random.Range (0, 0.01f);
		}
	}
}
