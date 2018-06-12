using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateChecker : MonoBehaviour
{
    [SerializeField]
    bool isAchieved = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " went through gate");

        if (!isAchieved)
        {
            Game.OnGateAchieved();
            isAchieved = true;
        }
    }
}
