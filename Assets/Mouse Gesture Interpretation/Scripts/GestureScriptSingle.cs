using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class GestureScriptSingle : MonoBehaviour
{
    public Texture2D texture;
    public GameObject player;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //This method is needed for the Gesture to run, here you set Texture for recognition and can set the sucess rate needed to be achived
    void setGestureConfig()
    {
        if (player == null)
        {
            Debug.LogError("<b>GestureScript:</b> The code need a reference to the object that has the playerInput script");
            return;
        }
        player.GetComponent<GesturePlayer.PlayerInput>().setTextureG(texture);
        //player.GetComponent<GesturePlayer.PlayerInput>().setCorrectRate(0.8f);
    }

    void onGestureCorrect()
    {
        Debug.Log("Correct " + texture.name);
        this.gameObject.GetComponent<Renderer>().material.color = Color.green;

        TrackManager.RemoveWall(this.gameObject);
    }

    void onGestureWrong()
    {
        Debug.Log("Wrong " + texture.name);
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
