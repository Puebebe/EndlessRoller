using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    private static GameObject lastAchievedGate;

    public static GameObject LastAchievedGate
    {
        get
        {
            return lastAchievedGate;
        }

        set
        {
            lastAchievedGate = value;
        }
    }

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
        var prefab = (GameObject) Resources.Load("Gate");
        var lastPosition = lastAchievedGate.transform.position;
        var position = new Vector3(lastPosition.x, lastPosition.y, lastPosition.z + 30);
        var rotation = prefab.transform.rotation;
        var parent = GameObject.Find("Gates").transform;

        var gate = Instantiate(prefab, position, rotation, parent);
        gate.name = "Gate";
        gate.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.yellow;

        Debug.Log("gate " + gate.transform.position);
        Debug.Log("New gate set");
    }

    void OnDestroy()
    {
        Game.GateAchieved -= UpdateScore;
        Game.GateAchieved -= SetNewGate;
    }
}
