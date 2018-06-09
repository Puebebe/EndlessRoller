using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Game.GateAchieved += UpdateScoreText;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("score = " + Game.Points);
    }

    void UpdateScoreText()
    {
        Debug.Log("score => " + Game.Points);
        GetComponent<Text>().text = "Score: " + Game.Points;
    }
}
