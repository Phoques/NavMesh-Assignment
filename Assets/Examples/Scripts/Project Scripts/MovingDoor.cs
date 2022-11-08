using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDoor : MonoBehaviour
{
    /// <summary>
    /// See Moving Platform script for notes, as this functions the same way except it doesnt 'pause' with a coroutine.
    /// </summary>

    #region Variables
    public List<Transform> waypoints;
    public float moveSpeed;
    public int target;
    #endregion
    #region Update and Fixed Update
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, moveSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if(transform.position == waypoints[target].position)
        {
            if(target == waypoints.Count - 1)
            {
                target = 0;
            }
            else
            {
                target += 1;
            }
        }
        
    }
    #endregion

}
