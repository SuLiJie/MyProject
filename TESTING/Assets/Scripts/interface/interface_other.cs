using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interface_other : MonoBehaviour {
	public static int fuking = 1;
	public static bool  switch_=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Click(Text btn_text){
		if(fuking%2==0)
			btn_text.text = "p";
		if(fuking%2!=0)	
			btn_text.text = "P";
		fuking++;
	}
	public int add_(int a,int b){
		return a + b;
	}
}
