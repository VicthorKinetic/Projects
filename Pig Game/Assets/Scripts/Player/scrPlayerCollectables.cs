using UnityEngine;
using System.Collections;

public class scrPlayerCollectables : MonoBehaviour {


	public scrUI UI;
	public int Score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "CollectableBlue") {
			Score = Score + 10;
			UI.ScoreUp ();
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "CollectableYellow") {
			Score = Score + 20;
			UI.ScoreUp ();
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "CollectableRed") {
			Score = Score + 30;
			UI.ScoreUp ();
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "CollectableGreen") {
			Score = Score + 50;
			UI.ScoreUp ();
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == "CollectablePurple") {
			Score = Score + 100;
			UI.ScoreUp ();
			Destroy (col.gameObject);
		}
	}
}
