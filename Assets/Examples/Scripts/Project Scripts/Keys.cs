using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    //Renderer reference
    MeshRenderer m_Renderer;
    public GameObject key;
    //Reference to another class
    AiMovement aiMovement;


    private void Start()
    {
        //Assigning the variables
        m_Renderer = GetComponent<MeshRenderer>();
        aiMovement = FindObjectOfType<AiMovement>();
    }

    /// <summary>
    /// If our agent, who has the tag AiAgent, touches the key, make its renderer disabled so it 'dissapears'
    /// </summary>
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AiAgent" && aiMovement.relicsFound == true)
        {
            m_Renderer.enabled = false;
            aiMovement.keyFound = true;

        }
        else return;
    }
}
