using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class mangement : MonoBehaviour {
	//---------Gameobject-----------------
	public GameObject[] train = new GameObject[4],
	Dtrain = new GameObject[11],
	trackModStore=new GameObject[4];//隨機自動生成軌道陣列
	public static GameObject[] trackModBorned;
	public static GameObject[] orderStore=new GameObject[4];
	public GameObject trainList,
	picture,
	cam,
	sound,
	destroyer,
	gameover;
	GameObject new_train, firstOne;
	//---------Gameobject-----------------

	//---------Vector3--------------------
	Vector3 pos,//出生位置
	C_pos=new Vector3(-4.9f,2.4f,-31.5f);//攝影機生成位置=玩家生成位置+設定距離(C_pos)
	//---------Vector3--------------------

	//---------Value----------------------
	public static float player_hp=1;//玩家可用加速數量
	public static int totalTrainCount=3,//總列車數量-1
	game_state=0;//遊戲狀態
	int TrainCount=0,//生成順序
	alreadyBornTrain=0,
	alreadyBornTrack=0;
	//---------Value----------------------

	//----------UI------------------------
	public Scrollbar speedUpControlBar,
	speedDownControlBar;
	public RawImage pointer;
	//----------UI------------------------

	void Awake(){
		rollerCoaster.manageScript = GameObject.Find ("gameManager").transform.GetComponents<mangement> ();
		rollerCoaster.tracks = GameObject.FindGameObjectsWithTag("track");
		Object destroyerLoad=Resources.Load("Gameobject/trackDestroyer");
		trackModBorned = GameObject.FindGameObjectsWithTag ("trackMod");
		destroyer = Instantiate (destroyerLoad) as GameObject;
		totalTrainCount = Open._difficulty;
        buildTrack();
        //paste();
    }
    void Start () {
		pos = GameObject.Find ("start").transform.position;

		bornTrain ();
		trackModBorned = GameObject.FindGameObjectsWithTag ("trackMod");
	}

	void Update () {
		trackBulider ();
        rollerCoaster.trainlist = GameObject.FindGameObjectsWithTag ("train");	
		switch (game_state) {
		case 0:
			if (Vector3.Distance (firstOne.transform.position, pos) > 8) {
				bornTrain ();
			}
			if (TrainCount > totalTrainCount) {
				game_state = 1;//第一輪列車生成結束，以上只跑一次
			}
			break;

			//---------------沒有列車在軌道上--------------//---------------確認順序後生成------------------
		case 1:
		if (GameObject.FindGameObjectsWithTag ("train").Length == 0) {
			randomSort ();
			rollerCoaster.manageScript = GameObject.Find ("gameManager").transform.GetComponents<mangement> ();
			game_state = 0;
			TrainCount = 0;
			bornTrain ();
			}
			break;
		case 2:
			gameover.SetActive(true);
			if (Input.anyKeyDown) {
				gameover.SetActive(false);
				game_state = 0;
				SceneManager.LoadScene (0);
			}
			break;
		}
	}
		

	//----------------------------列車生成-------------------------------
	void bornTrain(){
		new_train = Instantiate (train[TrainCount], pos, transform.rotation);
		new_train.transform.parent = trainList.transform;
		firstOne = new_train;
		orderStore [TrainCount] = new_train;
		if (new_train.name == "player(Clone)") {
			cam.transform.position = C_pos+new_train.transform.position;
		}
		TrainCount++;
	}
		

	/// <summary>
	/// Randoms the sort.
	/// 隨機排序，用洗牌排序法不重複陣列內容
	/// 隨機的範圍是尚未被摧毀的列車
	/// </summary>
	void randomSort(){
		for (int i = 0; i < 11; i++) {
			int n1 = Random.Range (0, totalTrainCount);
			int n2 = Random.Range (0, totalTrainCount);
			GameObject temp=train[n1];
			train [n1] = train [n2];
			train [n2] = temp;
		}
	}
	/// <summary>
	/// Bulids the track.
	/// 軌道生成於軌道模組的末端
	/// End重新命名
	/// </summary>
	public void buildTrack(){
		
		Vector3 trackPos;
		GameObject end=GameObject.Find ("end");
		GameObject newTrack;
		trackPos=end.transform.position + new Vector3 (-1.2f, 0, 0);
		newTrack=Instantiate (trackModStore [Random.Range(0,3)], trackPos,transform.rotation);
		end.name="cube";
		alreadyBornTrack++;
		if (alreadyBornTrack>=3) {//生成軌道數量到達N個之後，在第N-1個軌道末端生成軌道破壞
			destroyer.transform.position = end.transform.position + new Vector3 (0,1.2f,0);
			alreadyBornTrack = 1;
		}
		newTrack.transform.parent = GameObject.Find ("allTrack").transform;
	}
	//-------------------貼圖功能------------
	public void paste(){
		rollerCoaster.tracks = GameObject.FindGameObjectsWithTag("track");
		for (int i = 0; i < rollerCoaster.tracks.Length; i++) {
			Instantiate (picture, rollerCoaster.tracks [i].transform.position, rollerCoaster.tracks [i].transform.rotation);
		}
	}
	//---------------------------------------

	void trackBulider(){
		trackModBorned = GameObject.FindGameObjectsWithTag ("trackMod");
		rollerCoaster.tracks = GameObject.FindGameObjectsWithTag("track");
		if (trackModBorned.Length <4)
			buildTrack ();
	}

	/*Object obj=Resources.Load("Gameobject/Cube");
		GameObject track = Instantiate (obj) as GameObject;
		track.transform.parent = GameObject.Find ("track").transform;*/


	//----------------------------碰撞事件廣播-------------------------------*/
	/*private void EnterEvent(GameObject obj,  Collider collider){
		//Debug.Log("obj:" + obj.name + ", 撞到了:" + collider.name);//有剛體的是Obj
		/*if (obj.name=="start"&&collider.gameObject==order[train_count-1]) {//最尾端的列車撞道起始點，圈數+1
			turn++;
		}
		if (obj.tag == "bumper" && collider.tag == "train") {//撞到其他列車的尾端，刪除列車，列車數量-1
			destroyer = collider.gameObject;
			orderStroe.Remove (destroyer);
			//Destroy (destroyer);
			totalTrainCount--;
		}


		if (obj.name == "obstacle"&&collider.name!="bumper") {//撞到重新排序的點，刪除列車，準備重新生成
			destroyer = collider.gameObject;
			if (collider.name == "player") {//撞道的是player數值儲存起來以做玩家生成順序判定

				Destroy (destroyer);
			}
		}
	}*/

}
