using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class receive : MonoBehaviour {
	public static int answer=0;
	public Text ans;
	public GameObject a;
	// Use this for initialization
	void Start () {
		broadcast.sendevent += plus;
		broadcast.sendevent += minus;
		broadcast.sendevent += multi;
	}
	
	// Update is called once per frame
	void Update () {
		ans.text = ""+answer;
	}
	public void plus(int num,string function){
		if (function.Equals ("plus") == false)
			return;
		answer += num;
		Instantiate (a, new Vector3 (0, 0, 5.58f), Quaternion.identity);
	}
	public void minus(int num,string function){
		if (function.Equals ("minus") == false)
			return;
		answer -= num;
	}
	public void multi(int num,string function){
		if (function.Equals ("multi") == false)
			return;
		answer *= num;
	}
}
