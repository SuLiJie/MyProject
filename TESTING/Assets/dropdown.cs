using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dropdown : MonoBehaviour {
	public GameObject a0;
	public Transform a1;
	GameObject childgameobject;
	Vector3 born_pos=new Vector3(-313,72,509);
	int born_count=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void born(){
		born_pos.x += born_count * 20;
		childgameobject=Instantiate (a0, born_pos,new Quaternion(0,0,0,0));
		childgameobject.transform.SetParent (a1);
		born_count++;
	}
}
