using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

public class AiMovement : MonoBehaviour
{
   
    public NavMeshAgent _aiAgent;
    public Transform[] collectables;
    public Transform key;
    public Transform exitDoor;
    public Transform tree;
    int _collectableDestination;
    public bool relicsFound = false;
    public bool keyFound = false;
    public bool imOut = false;
    [SerializeField] float _speed = 5f;
    State _state;
    public enum State
    {
        SearchingRelics,
        SearchingKey,
        SearchingExit,
        Escaping
    }

    public void SearchState()
    {
        if (_collectableDestination < collectables.Length - 1)
        {
            _state = State.SearchingRelics;
            Debug.Log("Im searching for treasure");

        }
        else if (relicsFound)
        {
            _state = State.SearchingKey;
            Debug.Log("Im searching for a Key to get out");
        }
        else if (keyFound)
        {
            _state = State.SearchingExit;
            Debug.Log("Im searching for the Exit!");
        }
        else if (imOut)
        {
            _state = State.Escaping;
            Debug.Log("Cya later suckers!");
        }

    }

    /*public void ChangeState()
    {
        switch (_state)
        {
            case State.SearchingRelics:
                StartCoroutine(GoToNextCollectable());
                break;

        }


    }*/


    private void Awake()
    {
        _aiAgent = GetComponent<NavMeshAgent>();
        //_aiAgent.speed = _speed;
        GetComponent<NavMeshAgent>().speed = _speed; // Check this with Jaymie
    }

    private void Start()
    {
        _collectableDestination = -1;
        GoToNextCollectable();
        //SearchState();
        //ChangeState();
    }

    void Update()
    {
        SearchState();

        FindRelics();
        
        if (relicsFound)
        {
            FindKey();
        }

        if (keyFound)
        {
            MoveToExitDoor();
        }

        if (imOut)
        {
            MoveToTree();
        }

    }

    /*IEnumerator GoToNextCollectable()
    {
        while (_state == State.SearchingRelics)
        {

            if (_collectableDestination < collectables.Length - 1)
            {
            //Add +1 to the current count
            _collectableDestination++;
            //Head to the relics current position
            _aiAgent.destination = collectables[_collectableDestination].position;
            }
            //If collectable destinaton is greater than or equal to 2 (Being the last relic in the array.)
            else if (_collectableDestination >= collectables.Length - 1)
            {
            relicsFound = true;
            }
            else if (relicsFound)
            {
            yield return null;
            SearchState();
            }
        }
    }*/
    

    void GoToNextCollectable()
    {
        // If the destination's position in the array is less than 2 (The array has 3 elements, but they are 0,1,2. The LENGTH (or count for lists) is 3,
        // so LENGTH -1 is actually 2 (Which is the last relic being element 2.
        //If collectable destinaton is less than 2.
        if (_collectableDestination <  collectables.Length - 1)
        {
            //Add +1 to the current count
            _collectableDestination++;
            //Head to the relics current position
            _aiAgent.destination = collectables[_collectableDestination].position;
        }
        //If collectable destinaton is greater than or equal to 2 (Being the last relic in the array.)
        else if (_collectableDestination >= collectables.Length - 1)
        {
            relicsFound = true;
        }
    }


    void FindRelics()
    {
        // Distance might be for the path only, instead of the actual object. Vector3.Distance 
        if ( _aiAgent.remainingDistance < 0.5f 
            && Vector3.Distance(_aiAgent.transform.position, collectables[_collectableDestination].position) < 0.5f)
        {
            GoToNextCollectable();
        }
        
        else { return; }
    }

    void FindKey()
    {
        _aiAgent.destination = key.position;

        if (_aiAgent.remainingDistance < 0.5f
            && Vector3.Distance(_aiAgent.transform.position, key.position) < 0.5f)
        {
            keyFound = true;
        }
        else { return; }
    }


    void MoveToExitDoor()
    {
        _aiAgent.destination = exitDoor.position;

        if (_aiAgent.remainingDistance < 0.5f
            && Vector3.Distance(_aiAgent.transform.position, exitDoor.position) < 0.5f)
        {
            imOut = true;
        }
        else { return; }
    }

    
    void MoveToTree()
    {
        
        _aiAgent.destination = tree.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Mud")
        {
            _speed = 0.5f;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mud")
        {
            _speed = 5f;
        }
    }

    

}
