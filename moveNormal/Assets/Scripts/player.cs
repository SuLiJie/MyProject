using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player : rollerCoaster {
	 //GameObject train;
	Vector3 cam2train;
	GameObject cam;
	int state;
	

	// Use this for initialization
	void Awake(){
		//manageScript = GameObject.Find ("gameManager").transform.GetComponents<mangement> ();
	}
	void Start () {
		rollerCoaster.tracks = GameObject.FindGameObjectsWithTag("track");
		cam=GameObject.Find("Main Camera");
		cam2train = cam.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F2)) {
			mangement.game_state = 2;
			Destroy (gameObject);
		}
		order_check (gameObject);
		keepTrainOnTrack ();
		camFollowTrain();
		forward (now_Speed);
		speedControl ();
        pointContorl();
       
	}


	void camFollowTrain(){
		cam.transform.position = transform.position + cam2train;
	}

	//加速減速控制
	public void speedControl(){
		//speedDownControl ();
		speedUpControl ();
	}
    public void speedUpControl() {
        float rightBar = manageScript[0].speedUpControlBar.value;
        float leftBar = manageScript[0].speedDownControlBar.value;

        if (leftBar - rightBar < 0.1f || rightBar - leftBar < 0.1f){//左邊控制桿和右邊控制桿誤差不大於0.1的話
            now_Speed += ((leftBar + rightBar) / 2 - 0.5f) * 0.05f;//控制桿的初始值是0.5
        Debug.Log(leftBar + " " + rightBar+" "+ ((leftBar + rightBar) / 2 - 0.5f)); }
        if (Input.GetKeyDown (KeyCode.A))
			now_Speed += 0.05f;
			
	}
	public void speedDownControl(){
		now_Speed -= manageScript [0].speedDownControlBar.value * 0.05f;
		if (Input.GetKeyDown (KeyCode.D))
			now_Speed += 0.05f;
	}
    public void pointContorl()
    {
        float angle;
        angle = 250 - now_Speed * 70;
        if (angle > 250)
        {
            angle = 250;
        }
        if (angle < 100)
        {
            angle = 100;
        }
        manageScript[0].pointer.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}

