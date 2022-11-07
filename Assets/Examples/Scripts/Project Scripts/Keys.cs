using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    MeshRenderer m_Renderer;
    public GameObject key;
    AiMovement aiMovement;


    private void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        aiMovement = FindObjectOfType<AiMovement>();
    }

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
