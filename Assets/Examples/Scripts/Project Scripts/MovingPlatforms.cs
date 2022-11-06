using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public List<Transform> waypoints;
    public float moveSpeed;
    public int target;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, moveSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if (transform.position == waypoints[target].position)
        {
            StartCoroutine(MovingPlatform());

        }

    }
    IEnumerator MovingPlatform()
    {

        if (target == waypoints.Count - 1)
        {
            yield return new WaitForSeconds(5f);
            target = 0;
            
        }
        else
        {
            yield return new WaitForSeconds(5f);
            target = 1;

        }
        
    }

}
