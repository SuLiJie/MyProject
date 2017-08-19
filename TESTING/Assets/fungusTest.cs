using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class fungusTest : MonoBehaviour {
	public string test;
	public Flowchart NPCtalking;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void button (){
		Block targetblock = NPCtalking.FindBlock ("NPC");
		NPCtalking.ExecuteBlock (targetblock);
	}
}
