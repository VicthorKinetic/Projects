using UnityEngine;
using System.Collections;

public class scrCollectables : MonoBehaviour {



	public int Points = 0;
	public int Cristal = 0;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Cristal == 0) 
		{
			Points = 10;
		}

		if (Cristal == 1) 
		{
			Points = 20;
		}

		if (Cristal == 2) 
		{
			Points = 30;
		}

		if (Cristal == 3) 
		{
			Points = 50;
		}

		if (Cristal == 4) 
		{
			Points = 100;
		}
	
	}
}
