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
        GoToNextCollectable();
    }

    void Update()
    {
        FindRelics();

    }

    void GoToNextCollectable()
    { 
        //Switch statement?
        if (_collectableDestination == 0)
        {
        _aiOne.destination = collectables[_collectableDestination].position;
        _collectableDestination = (_collectableDestination + 1); // _collectableDestination++ (Short hand)
            // Maybe do a distance check, BEFORE doing the +1?
            Debug.Log("Finding 1st Relic");
        }
        else if(_collectableDestination == 1)
        {
            _aiOne.destination = collectables[_collectableDestination].position;
            _collectableDestination = (_collectableDestination + 1);
            Debug.Log("finding 2nd Relic");
        }
        else if(_collectableDestination == 2)
        {
            _aiOne.destination = collectables[_collectableDestination].position;
            _collectableDestination = (_collectableDestination + 1);
            Debug.Log("finding 3rd Relic");
        }
        else
        {
            return;
        }
        // THE COUNT IS FOR ALL SCRIPTS!!! THATS WHY??
    }


    void FindRelics()
    {
        // Distance might be for the path only, instead of the actual object. Vector3.Distance 
        if ( _aiOne.remainingDistance < 0.5f)
        {
            GoToNextCollectable();
        }
        else { return; }
    }

    // !_aiOne.pathPending &&

    //if (Vector3.Distance(_aiOne.nextPosition, collectables[_collectableDestination].position) < 1f)
}
