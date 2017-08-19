using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Open : MonoBehaviour {
	public Text difficulty;
	public static int _difficulty=3;

	public void begin(){
		
		SceneManager.LoadScene (1);
	}

	public void exit(){

	}
	public void difficultyUp(){
		if(_difficulty<5)
			difficultyChange(_difficulty++);
	}
	public void difficultyDown(){
		if(_difficulty>0)
			difficultyChange (_difficulty--);
		
	}
	public void difficultyChange(int difficult){
		difficulty.text = "" + difficult;
	}
}
