using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollerCoasterManger : MonoBehaviour {
	public int[] positionS=new int[5];
	//public int[] order=new int[2];
	int i,j;
	public GameObject player;
	public GameObject npc;
	void Awake(){
		Vector3 pos = new Vector3 (1.485f, -1.09f, -3.37f);

		Vector3 put = new Vector3 (1f, 0, 0);
		Vector3 startpos;
		startpos = pos - 2*put;
		Instantiate (player,pos,transform.rotation);
		Instantiate (npc,startpos,transform.rotation);
		//order [0] = playerStart;//0代表玩家 1~9代表NPC

	}
	// Use this for initialization
	void Start () {
		/*int playerStart = Random.Range (0, 1);

		positionS [0] = 1;//假設玩家亂數出來是0位置0有東西了
		for (i = 0; i <= positionS.Length; i++) {
			
			if (positionS [i] == 1) {

				startpos = startpos - put;
				Instantiate (player,startpos,transform.rotation);
				positionS [i] = 1;
				i += 1;//玩家出生的位置並放上然後跳下一台雲霄飛車
			}


			print (i);
		}*/
		Vector3 startpos = new Vector3(0,0,0);//雲霄飛車從這裡開始放
		Vector3 put = new Vector3 (0.15f, 0, 0);
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
