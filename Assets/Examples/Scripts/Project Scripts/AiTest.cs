using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

public class AiTest : MonoBehaviour
{
   
    public NavMeshAgent _aiOne;
    public Transform[] collectables;
    int _collectableDestination;

     



    private void Awake()
    {
        _aiOne = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _collectableDestination = -1;
        GoToNextCollectable();
    }

    void Update()
    {
        FindRelics();

    }

    void GoToNextCollectable()
    {
        if (_collectableDestination <  collectables.Length - 1)
        {
            _collectableDestination++; // _collectableDestination++ (Short hand)
            _aiOne.destination = collectables[_collectableDestination].position;
        }
    }


    void FindRelics()
    {
        // Distance might be for the path only, instead of the actual object. Vector3.Distance 
        if ( _aiOne.remainingDistance < 0.5f 
            && Vector3.Distance(_aiOne.transform.position, collectables[_collectableDestination].position) < 0.5f)
        {
            GoToNextCollectable();
        }
        else { return; }
    }

    // !_aiOne.pathPending &&

    //if (Vector3.Distance(_aiOne.nextPosition, collectables[_collectableDestination].position) < 1f)
}
