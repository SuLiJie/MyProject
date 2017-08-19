using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class broadcast : MonoBehaviour {
	public delegate	void send(int num, string function );
	public static event send sendevent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void sendto(int num,string function){
		sendevent ( num, function );
	}
	public void button1(){
		sendto (1,"plus");
	}
	public void button2(){
		sendto (2,"minus");
	}
	public void button3(){
		SceneManager.LoadScene (1);
		sendto (3,"multi");
	}
}
