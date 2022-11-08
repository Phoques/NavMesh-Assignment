using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

public class AiMovement : MonoBehaviour
{
    #region Variables
    //A reference to the NavmeshAgent & Animator type
    public NavMeshAgent _aiAgent;
    public Animator _anim;

    //All transform positions to help the AI navigate
    public Transform[] collectables;
    public Transform key;
    public Transform exitDoor;
    public Transform tree;
    int _collectableDestination;

    //bools to trigger states
    public bool relicsFound = false;
    public bool keyFound = false;
    public bool imOut = false;
    public bool isWalking = false;
    public bool isSlow = false;

    //Speed variable to ovveride NavmeshAgent speed
    public float _speed = 5f;

    #endregion
    #region Enum and State Machine
    State _state;
    public enum State
    {
        SearchingRelics,
        SearchingKey,
        SearchingExit,
        Escaping
    }

    /// <summary>
    /// If the statement is true, change which state is active state)
    /// </summary>
    public void SearchState()
    {
        if (_collectableDestination < collectables.Length - 1)
        {
            //Change state
            _state = State.SearchingRelics;
            Debug.Log("Im searching for treasure");

        }
        else if (relicsFound && !keyFound)
        {
            _state = State.SearchingKey;
            Debug.Log("Im searching for a Key to get out");
        }
        else if (relicsFound && keyFound && !imOut)
        {
            _state = State.SearchingExit;
            Debug.Log("Im searching for the Exit!");
        }
       else if(imOut)
        {
            _state = State.Escaping;
            Debug.Log("Cya later suckers!");
        }
        ChangeState();
    }

    
    /// <summary>
    /// What action to take when the state has changed
    /// </summary>
    public void ChangeState()
    {
        switch (_state)
        {
            case State.SearchingRelics:
                FindRelics();
                break;
            case State.SearchingKey:
                FindKey();
                break;
            case State.SearchingExit:
                MoveToExitDoor();
                break;
            case State.Escaping:
                MoveToTree();
                break;
            default:
                Debug.Log("No state HALP");
                break;
        }
    }
    #endregion
    #region Awake, Start, Update
    private void Awake()
    {
        //Setting variable to get NavmeshAgent type
        _aiAgent = GetComponent<NavMeshAgent>();
        //Ovveriding the Navmesh Agent speed, so it can be influenced / controlled by code.
        GetComponent<NavMeshAgent>().speed = _speed;
        //because our animator is on a child object...do this
        _anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        //Set the initial collectable destination count
        _collectableDestination = -1;
        //Set the count on initilisation
        GoToNextCollectable();
        //Set initial bools to make the agent appear to be walking
        _anim.SetBool("isWalking", true);
        _anim.SetBool("isSlow", false);

    }

    void Update()
    {
        //Constantly check for state changes
        SearchState();
    }
    #endregion
    #region Functions
    void GoToNextCollectable()
    {
       
       
        // If the destination's position in the array is less than 2 (The array has 3 elements, but they are 0,1,2. The LENGTH (or count for lists) is 3,
        // so LENGTH -1 is actually 2 (Which is the last relic being element 2.
        //If collectable destinaton is less than 2.
        if (_collectableDestination <  collectables.Length - 1)
        {
            //Add +1 to the current count
            _collectableDestination++;
            //Ai Agent heads to the relics current position
            _aiAgent.destination = collectables[_collectableDestination].position;
        }
        //If collectable destinaton / array index / element is greater than or equal to 2 (Being the last relic in the array.)
        else if (_collectableDestination >= collectables.Length - 1)
        {
            relicsFound = true;
        }
    }
    void FindRelics()
    {
        // if the Agent is close to the collectable, move to the next one. 
        if ( _aiAgent.remainingDistance < 0.5f 
            && Vector3.Distance(_aiAgent.transform.position, collectables[_collectableDestination].position) < 0.5f)
        {
            GoToNextCollectable();
        }
        
        else { return; }
    }

    void FindKey()
    {// Set the Agent to move to the key position
        _aiAgent.destination = key.position;
        // if the Agent is close to the key, trigger bool for next state
        if (_aiAgent.remainingDistance < 0.5f
            && Vector3.Distance(_aiAgent.transform.position, key.position) < 0.5f)
        {
            keyFound = true;
        }
        else { return; }
    }


    void MoveToExitDoor()
    {// Set the Agent to move to the key position
        _aiAgent.destination = exitDoor.position;
        // if the Agent is close to the key, trigger bool for next state
        if (_aiAgent.remainingDistance < 0.5f
            && Vector3.Distance(_aiAgent.transform.position, exitDoor.position) < 0.5f)
        {
            imOut = true;
        }
        else { return; }
    }

    
    void MoveToTree()
    {
        // Set the Agent to move to the final 'winning' position.
        _aiAgent.destination = tree.position;
    }
    #endregion
    #region Collider checks and triggers
    private void OnTriggerEnter(Collider other)
    { // If the agent collides with the tagged MUD object
        if (other.gameObject.tag == "Mud")
        {
            Debug.Log("Enter Mud");
            _speed = 0.5f; // change speed variable
            //Set animation bools
            _anim.SetBool("isWalking", false);
            _anim.SetBool("isSlow", true);
            Debug.Log("OW MY BACK");

        }
        //Override NavMeshAgent speed for our variable.
        GetComponent<NavMeshAgent>().speed = _speed;
        //The above needs to be called any time there is a change, in this circumstance it needs to be called to set the speed back to 5f after it enters.


    }
    private void OnTriggerExit(Collider other)
    {
        // As above but when we exit the mud.
        if (other.gameObject.tag == "Mud")
        {
            Debug.Log("Exit Mud");
            _speed = 5f;
            _anim.SetBool("isWalking", true);
            _anim.SetBool("isSlow", false);
            Debug.Log("Im walking heeeeere");
        }
        GetComponent<NavMeshAgent>().speed = _speed;
        //The above needs to be called any time there is a change, in this circumstance it needs to be called to set the speed back to 5f after it exits.

    }
    #endregion


}
