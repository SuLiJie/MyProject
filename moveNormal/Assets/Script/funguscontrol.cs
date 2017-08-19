using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class funguscontrol : MonoBehaviour {
    public Flowchart flow1;
    public SayDialog dialog1;

    private string[][] Array;
    
    string say1 = "Go to Heaven";
    string blockName;

	// Use this for initialization
	void Start () {

        TextAsset binAsset = Resources.Load("a1", typeof(TextAsset)) as TextAsset;
        Debug.Log(binAsset);
        string[] lineArray = binAsset.text.Split("\r"[0]);
        Debug.Log(lineArray.Length);

        Array = new string[lineArray.Length][];
		Debug.Log (lineArray[0]);
		Array[0] = lineArray[0].Split(',');
		Debug.Log (Array [0][0]);
        for (int i = 1; i < lineArray.Length; i++)
        {
            Array[i] = lineArray[i].Split(',');

            addSay("Dead", Array[i], i );
            
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //加入台詞
    private void addSay(string blockName, string[] array, int i)
    {
        GameObject chara_name;
        Block block = flow1.FindBlock(blockName);
        Say customSay = block.gameObject.AddComponent<Say>();
        Character char1 = customSay.gameObject.AddComponent<Character>();
        dialog1.gameObject.SetActive(true);
        customSay.storyText = array[3];
        customSay.parentBlock = block;
        block.commandList.Insert(i, customSay);
        customSay.setSayDialog = dialog1;
        customSay.character = char1;
        if(array[1] == "Milian")
        {
            char1.nameText = "米莉安";
            customSay.portrait = Resources.Load<Sprite>("Milian");
        }
        else if(array[1] == "Dad")
        {
            char1.nameText = "厄魯道夫";

        }
        else
        {
            char1.nameText = "  ";
        }



    }

    //加入新Block
    private void addBlock(string blockName)
    {
        Block block01 = flow1.gameObject.AddComponent<Block>();
        block01.blockName = blockName;
        
    }

    //輸入座標獲取數值
    public string GetData(int nRow, int nCol)
    {
        if (Array.Length <= 0 || nRow >= Array.Length)
        {
            return "";
        }
        if (nCol >= Array[0].Length)
        {
            return "";
        }
        return Array[nRow][nCol];
    }

    //抓表情
    public string GetExpression(string id)
    {
        for (int i = 0; i < Array.Length; i++)
        {
            //string strId = string.Format("\n{0}", id);  
            if ((string)Array[i][0] == id)
            {
                return Array[i][2];
            }
        }

        return "";
    }

}
