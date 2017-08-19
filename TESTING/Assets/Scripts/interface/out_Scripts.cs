using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class out_Scripts : interface_other {
	public Text outtext;
	// Use this for initialization
	interface_other fucking = new interface_other ();
	interface_class test=new interface_class();
	public Text btntext;
	void Start () {
		outo a=(outo)test;
		a.je (outtext);

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (interface_other.fuking);

	}
	public void getint(){
		outtext.text="now fuck me"+fucking.add_ (1, 2);
	}

}
interface outo{
	void je(Text text);
}
class interface_class: interface_other,outo{
	public void je(Text text){
		text.text="fuck";
	}
}
