using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static event Action GateAchieved;

    private static int points;
    public static int Points
    {
        get
        {
            return points;
        }

        set
        {
            points = value;
            //UI
        }
    }


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

    }

    public static void OnGateAchieved()
    {
        if (GateAchieved != null)
        {
            GateAchieved.Invoke();    //wywolanie wszystkich funkcji podpietych pod event
        }
    }
}
