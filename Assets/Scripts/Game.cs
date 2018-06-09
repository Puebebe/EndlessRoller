using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            GameObject.Find("Score").GetComponent<Text>().text = "Score: " + points;
        }
    }

    public static void OnGateAchieved()
    {
        if (GateAchieved != null)
        {
            GateAchieved.Invoke();    //wywolanie wszystkich funkcji podpietych pod event
        }
    }
}
