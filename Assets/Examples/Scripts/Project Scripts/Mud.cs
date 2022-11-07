using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mud : MonoBehaviour
{
   // NavMeshAgent agent;
    AiMovement aiMovement;
        
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        aiMovement = FindObjectOfType<AiMovement>();
        aiMovement = GetComponent<AiMovement>();
        
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AiAgent")
        {
            aiMovement._speed = 1f;
        }
        else return;
    }*/
}
