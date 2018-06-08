using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    void Start()
    {
        Game.GateAchieved += UpdateScore;
        Game.GateAchieved += SetNewGate;
    }

    //wszystkie te metody podepnie sie pod event wlasny, albo jakis Trigger na obiekcie (bez mesha)
    //potem event.Invoke() w onGestureCorrect()
    //moze Static?

    public static void RemoveWall(GameObject wall)
    {
        Destroy(wall);
        Debug.Log("Wall destroyed");
    }
    
    void UpdateScore()
    {
        Game.Points++;
        Debug.Log("Score updated");
    }

    void SetNewGate()
    {
        //instantiate z prefaba z losowa tekstura itd.
        Debug.Log("New gate set");
    }

    void OnDestroy()
    {
        Game.GateAchieved -= UpdateScore;
        Game.GateAchieved -= SetNewGate;
    }
}
