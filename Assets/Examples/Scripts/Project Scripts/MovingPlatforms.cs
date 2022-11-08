using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    #region Variables
    //A list of transform positions
    public List<Transform> waypoints;
    public float moveSpeed;
    public int target;

    #endregion
    #region Update and FixedUpdate

    void Update()
    {//position of this game object need to move towards the target (set in inspector) of the list of waypoints, at movespeed, normalised.
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, moveSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //If this objects position is equal to the assigned target
        if (transform.position == waypoints[target].position)
        {
            StartCoroutine(MovingPlatform());

        }

    }

    #endregion
    #region Coroutine
    IEnumerator MovingPlatform()
    {
        // If the assigned target is equal to the end of the list, the target is waypoint 0 / target 0.
        if (target == waypoints.Count - 1)
        {
            yield return new WaitForSeconds(5f);
            target = 0;
            
        }
        else
        {
            //Else move towards target 1
            yield return new WaitForSeconds(5f);
            target = 1;

        }
        
    }
    #endregion
}
