using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventa : MonoBehaviour {

	public delegate void sendMessage(GameObject obj,  Collider collider);//宣告委派，該委派無返回值、有三個傳入的參數
	public static event sendMessage sendEvent;//宣告事件，該事件必須為public static

	private void Message(GameObject obj,  Collider collider){
		//sendEvent(obj, collider);
	}

	private void OnTriggerEnter(Collider collider){
		//這個gameObject為該script所放置的物件
		//假設該script放在CubeA，則gameObject代表的就是CubeA
		Message(gameObject,  collider);
	}
}
