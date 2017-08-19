using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class excelTest : MonoBehaviour {
	private string [][]Array;
	// Use this for initialization
	void Start () {
		TextAsset binAsset = Resources.Load ("unity_text", typeof(TextAsset))as TextAsset;
		Debug.Log (binAsset);
		string[] lineArray = binAsset.text.Split ("\r" [0]);

		Array = new string[lineArray.Length][];

		for (int i = 0; i < lineArray.Length; i++) {
			Array[i] = lineArray[i].Split (',');  
		}
  
		Debug.Log (GetData (2, 0));
		Debug.Log (Array.Length);
		Debug.Log (GetExpression ("\na1"));
	}
	

	//輸入座標獲取數值
	public string GetData(int nRow, int nCol){  
		if (Array.Length <= 0 || nRow >= Array.Length) { 
			return "";
		}
		if (nCol >= Array[0].Length){  
			return "";  
		}
		return Array[nRow][nCol];  
	}

	//抓ID和第一行
	/*public string GetDataByIdAndName(int nId, string strName) {  
		if (Array.Length <= 0)  
			return "";  

		int nRow = Array.Length;  
		int nCol = Array[0].Length;       
		for (int i = 1; i < nRow; ++i) {  
			string strId = string.Format("\n{0}", nId);  
			if (Array[i][0] == strId) {  
				for (int j = 0; j < nCol; ++j) {  
					if (Array[0][j] == strName) {  
						return Array[i][j];  
					}  
				}  
			}  
		}  

		return "";  
	}*/

	//抓表情
	public string GetExpression(string id){
		for (int i = 0; i < Array.Length; i++) {
			//string strId = string.Format("\n{0}", id);  
			if ((string)Array [i] [0] == id) {
				return Array [i] [2];
			}
		}

		return "";
	}

}
