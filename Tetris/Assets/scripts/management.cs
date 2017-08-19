using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class management : MonoBehaviour {
	public GameObject square,downSquareGroup;
	public GameObject[] squareGroup=new GameObject[7];
	public static float squareDis=0.56f;//一個方塊的距離
    public GameObject[,] squareGrid = new GameObject[9,17];//總座標
    public static float speedTime,//下降速度
                        downTime; //下降的時間
    public static bool downing=true;
    Vector2 pos = new Vector2(-6.2066f, -4.55f);//原點
    public Vector2 bornpos;
    // Use this for initialization
    void Start () {
        /*for (int j = 0; j < 17; j++) {//將方塊填滿
			for (int i = 0; i < 9; i++) {
				Instantiate (square, pos, new Quaternion (0, 0, 0, 0));
				pos.x += squareDis;
			}
			pos.x = posX;
			pos.y += squareDis;
		}*/

        /*for (int i = 0; i < squares.Length; i++) {//算出陣列內座標方法
			Debug.Log (Mathf.Round((squares [i].transform.position.x+6.2f)/0.56f));
			//Debug.Log (Mathf.Round((squares [i].transform.position.y+4.55f)/0.56f));
		}*/
        
        GameObject start = GameObject.Find ("bornpos");
		bornpos = start.transform.position;
        bornSquareGroup();
    }
	
	// Update is called once per frame
	void Update () {
        speedTime += Time.deltaTime;
        downTime += Time.deltaTime;
   
        if(downing)
            control(downSquareGroup);
        if (!downing)
        {
            removeComponet();
            newGrid();
            regulared();
            bornSquareGroup();
        }

    }
    public void bornSquareGroup()                                             //方塊生成
    {
        downSquareGroup = Instantiate(squareGroup[Random.Range(0, 6)], bornpos, new Quaternion(0, 0, 0, 0));
        downing = true;
    }                                          

    public void control(GameObject squareGroup)                               //控制方塊下降以及左右移動
    {
        if (speedTime >= 1.5f || Input.GetKey(KeyCode.S))
        {                                                  //1秒下降1個方塊距離
            squareGroup.transform.position += new Vector3(0, -squareDis / 2);
            speedTime = 0;
        }
        if (Input.GetKeyDown(KeyCode.A) )
            squareGroup.transform.position += new Vector3(-squareDis, 0);
        if (Input.GetKeyDown(KeyCode.D) )
            squareGroup.transform.position += new Vector3(squareDis, 0);
        if (Input.GetKeyDown(KeyCode.W) )
            squareGroup.transform.Rotate(0, 0, 90);

    }

    public void gridReturn(GameObject square, Vector2 pos)                     //計算方塊座標位置
    {
        float x, y;
        x = (pos.x + 6.2f) / 0.56f;
        y = (pos.y + 4.55f) / 0.56f;
        squareGrid[(int)Mathf.Round(x), (int)Mathf.Round(y)] = square;
    }

    public void newGrid()                                                     //當方塊到底時，重新分配座標，並且呼叫判斷是否可以清除
    {
        GameObject[] squares = GameObject.FindGameObjectsWithTag("square");
        for (int i = 0; i < squares.Length; i++)
            if (squares[i].transform.position.y < 4.5)
                gridReturn(squares[i], squares[i].transform.position);
            else
                continue;
        Isfull();
    }

    public static bool IsDown(GameObject squareGroup)
    {
        /*int temp=0;
        if (downTime >= 0.5f)
        {
            if (temp == (int)Mathf.Round((squareGroup.transform.position.y + 4.55f) / 0.56f))
                return false;
            else { 
                downTime = 0;
                temp = (int)Mathf.Round((squareGroup.transform.position.y + 4.55f) / 0.56f);
                return true;
            }
        }
        else*/
        return true;
    }

    public void Isfull()                                                      //判斷是否有一列可以消除
    {
       
        for(int i = 0; i < squareGrid.GetLength(1); i++)
        {
            int full = 0;
            for (int j = 0; j < squareGrid.GetLength(0); j++)
            {
                if (squareGrid[j, i] == null)
                    break;
                if (squareGrid[j, i] != null)
                    full++;
                if (full == 9)                                                  //假如那一列已經滿了，呼叫function清除該列
                    destroyRow(i);
                
            }
        }
    }

    public void destroyRow(int row)                                            //清除滿行的該列
    {
        for(int i = 0; i < squareGrid.GetLength(0); i++)
        {
            Destroy(squareGrid[i, row]);
            Debug.Log(i + " " + row);
        }
        if (row != squareGrid.GetLength(1))                                    //清除完後判斷是否為最上方的列，為否的話呼叫function調降上方所有方塊
            allSquarePosDown(row + 1);
    }

    public void allSquarePosDown(int row)                                      //清除該列後上方所有方塊下降 BUG一堆
    {
        for(int i = 0; i < squareGrid.GetLength(0); i++)
        {
            for(int j = row; j < squareGrid.GetLength(1); j++)
            {
               // if (squareGrid[i, j] != null)
                //{
                    Debug.Log(i + " " + j);
                    // squareGrid[i, j].transform.position = new Vector3(10, 5);//(i * 0.56f - 6.2f, (j-1) * 0.56f - 4.55f,0);
                    squareGrid[i, j - 1] = squareGrid[i, j];
                //}
                //else
                    //continue;
            }
        }
        for(int i = 0; i < squareGrid.GetLength(0); i++)
        {
            for(int j = 0; j < squareGrid.GetLength(1); j++)
            {
                Debug.Log(squareGrid[i, j] + " " + i + " " + j);
            }
        }
        //regulared();
    }

    public void removeComponet()                                               //到底之後移除屬性
    {
        Destroy(downSquareGroup.GetComponent<Rigidbody2D>());
        Destroy(downSquareGroup.GetComponent<collision>());
    }

    public void regulared()                                                     //方塊重新整理
    {
        for(int i=0; i < squareGrid.GetLength(1); i++)
        {
            for(int j = 0; j < squareGrid.GetLength(0); j++)
            {
                if (squareGrid[j, i] != null)
                    squareGrid[j, i].transform.position = new Vector3(j*0.56f-6.2f,i*0.56f-4.55f);
                else
                    continue;
            }
        }
    }

    public void removeParent(GameObject paObj)                                                  //移除父物件
    {
        int count = paObj.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            Debug.Log(paObj.transform.childCount);
            paObj.transform.GetChild(i).gameObject.transform.parent = null;
        }
        Destroy(paObj);
    }
}
