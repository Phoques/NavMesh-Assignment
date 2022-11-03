using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    MeshRenderer m_Renderer;
    public GameObject collectable;


    private void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "AiAgent")
        {
            m_Renderer.enabled = false;
            // Maybe use the FindNextRelic function here, instead of doing a distance check?
        }
    }
}
