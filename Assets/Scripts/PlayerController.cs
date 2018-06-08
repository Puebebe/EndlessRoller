using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float horizontalSpeed = 4f;
    [SerializeField]
    float forwardSpeed = 10f;
    Vector3 startPosition;

    // Use this for initialization
    void Start ()
    {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {   
        Vector3 movement = Vector3.zero;


        #if UNITY_ANDROID && !UNITY_EDITOR
        movement = new Vector3(Input.acceleration.x, 0, - Mathf.Clamp(Input.acceleration.z + 0.5f, -0.2f, 0.2f));
        GameObject.Find("Movement").GetComponent<Text>().text = "" + movement.magnitude + "\n" + Input.acceleration.z;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = startPosition;
        }

        #else
        //Debug.Log("Horizontal: " + Input.GetAxis("Horizontal") + " Vertical: " + Input.GetAxis("Vertical"));
        movement = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * horizontalSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * forwardSpeed);
        //Debug.Log("GetAxis input: " + movement.magnitude);

        #endif

        GetComponent<Rigidbody>().velocity += movement;
    }
}
