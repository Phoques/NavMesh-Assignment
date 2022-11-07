using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryDoor : MonoBehaviour
{
    public GameObject victoryDoor;
    public Transform openSesame;
    public float moveSpeed;
    bool _openSesame = false;

    private void Update()
    {
        if (_openSesame)
        {
            OpenDoor();
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AiAgent")
        {
            _openSesame = true;
        }
    }*/

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
