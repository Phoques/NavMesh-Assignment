using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTest : MonoBehaviour
{

    public GameObject _relics;

    List<GameObject> _collectables = new List<GameObject>();

    void Start()
    {
        _collectables.Add(_relics);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
