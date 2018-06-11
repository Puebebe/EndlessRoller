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
        var prefab = (GameObject) Resources.Load("Gate");
        var gate = Instantiate(prefab);
        gate.transform.SetParent(GameObject.Find("Gates").transform);
        Debug.Log("gate " + gate.transform.position);
        Debug.Log("New gate set");
    }

    void OnDestroy()
    {
        Game.GateAchieved -= UpdateScore;
        Game.GateAchieved -= SetNewGate;
    }
}
