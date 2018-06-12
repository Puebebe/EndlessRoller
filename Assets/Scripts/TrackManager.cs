using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField]
    GameObject lastSetGate;

    [SerializeField]
    List<Texture2D> textures;

    int nextGate = 3;

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
        var lastPosition = lastSetGate.transform.position;
        var position = new Vector3(lastPosition.x, lastPosition.y, lastPosition.z + 10);
        var rotation = prefab.transform.rotation;
        var parent = GameObject.Find("Gates").transform;

        var gate = Instantiate(prefab, position, rotation, parent);
        gate.name = "Gate" + nextGate++;

        var wall = gate.transform.GetChild(0);
        Texture2D texture = textures[Random.Range(0, textures.Count)];
        wall.GetComponent<Renderer>().material.mainTexture = texture;
        wall.GetComponent<GestureScriptSingle>().player = GameObject.Find("Player");
        wall.GetComponent<GestureScriptSingle>().texture = texture;
        
        Debug.Log(gate.name + " set");

        lastSetGate = gate;
    }

    void OnDestroy()
    {
        Game.GateAchieved -= UpdateScore;
        Game.GateAchieved -= SetNewGate;
    }
}
