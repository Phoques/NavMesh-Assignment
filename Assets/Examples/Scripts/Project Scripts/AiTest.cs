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
        if (_collectableDestination == 0)
        {
        _aiOne.destination = collectables[_collectableDestination].position;
        _collectableDestination = (_collectableDestination + 1);
        }
        else if(_collectableDestination == 1)
        {
            _aiOne.destination = collectables[_collectableDestination].position;
            _collectableDestination = (_collectableDestination + 1);
        }
        else if(_collectableDestination == 2)
        {
            _aiOne.destination = collectables[_collectableDestination].position;
            _collectableDestination = (_collectableDestination + 1);
        }
        else
        {
            return;
        }

    }


    void FindRelics()
    {
        if ( _aiOne.remainingDistance < 0.5f)
        {
            GoToNextCollectable();
        }
        else { return; }
    }

    // !_aiOne.pathPending &&


}
