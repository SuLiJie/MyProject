using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rollerCoaster : MonoBehaviour {
	
	public static GameObject[] tracks;
	public static GameObject[] trainlist;
	GameObject closesetTrack;
	Transform oParent;
	public static mangement[] manageScript;
	public static int order;
	//public int realOrder;
	public float  now_Speed=0.2f;

	public GameObject getClosetTrack()
	{
		float dist = Mathf.Infinity;
		GameObject closesetTrack = null;

		foreach (var t in tracks){
			if (t == null)
				continue;
			float tempDist = Vector3.Distance(transform.position, t.transform.position);
			if (tempDist < dist){
				dist = tempDist;
				closesetTrack = t;
				}
			}
		return closesetTrack;
	}
	public void keepTrainOnTrack()
	{
		//取得與我最近的軌道
		closesetTrack = getClosetTrack();
		//讓我跟最近的軌道一樣旋轉值
		setRoate(closesetTrack.transform.eulerAngles);
	}
	public void setRoate(Vector3 r)
	{
		transform.eulerAngles = r;
		transform.eulerAngles += new Vector3(0, 0, 90);
	}
	//-----------------------移動----------------------------
	public void forward(float speed)
	{
		//讓我浮在最近的軌道上面
		if (speed > 2)
			speed = 2;
		if (speed < 0) {
			speed = 0;
			//Destroy (gameObject);
		}
		oParent = transform.parent;
		transform.parent = closesetTrack.transform;
		transform.localPosition = new Vector3(transform.localPosition.x, 3, 0);
		transform.position += transform.up * (speed)/*speed*/;
		transform.parent = oParent;
	}
	public void backward(float speed)
	{
		oParent = transform.parent;
		transform.parent = closesetTrack.transform;
		transform.localPosition = new Vector3(transform.localPosition.x, 3, 0);
		transform.position -= transform.up * (speed)/*speed*/;
		transform.parent = oParent;
	}


	public void OnTriggerEnter(Collider tri){
		if (tri.gameObject.name== "bumper"&&mangement.game_state!=0 ) {
			mangement.totalTrainCount--;
			Debug.Log ("touch" + gameObject.name);
			if (gameObject.name == "player(Clone)")
				mangement.game_state = 2;
			Destroy (gameObject);
		}
		if (tri.gameObject.name == "obstacle") {//隧道
			Destroy (gameObject);
		}
		if (tri.gameObject.tag == "trackDestroyer"&&gameObject.tag=="last") {
			for(int i = 0;i<2;i++){
				Destroy(mangement.trackModBorned[i]);
			}
		}

		//-------------限速器，速度小於0.2則破壞----------
		if (tri.gameObject.name=="speedup"&&now_Speed<0.3f) {
			//mangement.totalTrainCount--;
			//Destroy (gameObject);
		}
	}


	public void order_check(GameObject obj){
		int destroyedTrain=0;
		if (mangement.game_state != 0) {
			for (int i = 0; i < mangement.orderStore.Length; i++) {
				if (mangement.orderStore [i] == null) {
					destroyedTrain++;
					continue;

				}
				if (obj.name == mangement.orderStore [i].name) {
					order = i-destroyedTrain;
					if (order == mangement.totalTrainCount)
						gameObject.tag = "last";
				} 
			}
		}
	}

	/*public void orderInList(){
		for (int i = 0; i < mangement.totalTrainCount; i++) {
			if (manageScript[0].train[i].name + "(Clone)" == gameObject.name) {
					realOrder = i;
				}
			}
	}*/
	/// <summary>
	/// Destroyed the specified obj.
	/// 將被摧毀的列車移到洗牌排序法的範圍外
	/// </summary>
	/// <param name="obj">Object.</param>
	/*public void destroyed(rollerCoaster obj){
		GameObject temp;
		temp=manageScript [0].train [mangement.totalTrainCount];
		manageScript [0].train [mangement.totalTrainCount] = manageScript [0].train [obj.realOrder];
		manageScript [0].train [obj.realOrder] = temp;
		mangement.totalTrainCount--;
	}*/
}

