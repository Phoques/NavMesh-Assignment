using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryDoor : MonoBehaviour
{
    //references for the door object
    public GameObject victoryDoor;
    //Reference for a waypoint the door moves to
    public Transform openSesame;


    public float moveSpeed;
    bool _openSesame = false;

    private void Update()
    {//If this bool is triggered as true (As the agent now has a key)
        if (_openSesame)
        {
            //Make the door move to the waypoint so the Agent can move towards the end goal.
            OpenDoor();
        }
    }
    

    void OpenDoor()
    {
        transform.position = Vector3.MoveTowards(transform.position, openSesame.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "AiAgent")
        {
            _openSesame = true;
        }
    }

}
