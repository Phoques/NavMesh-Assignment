using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    /// <summary>
    /// See 'Keys' Script, as it works in the exact same way
    /// </summary>
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
            
        }
    }
}
