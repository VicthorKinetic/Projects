using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class scrUI : MonoBehaviour {


	public scrPlayerCollectables PC;
	public Text ScoreUI;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	public void ScoreUp()
	{
		ScoreUI.text = "Score:" + PC.Score;
	}
}
