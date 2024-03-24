using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavigator : MonoBehaviour
{
    [SerializeField] private Transform path;
    
    private List<Transform> waypoints = new List<Transform>();
    
    int pathIndex = 0;

    float speed = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        FindWaypoints();
    }

    private void FindWaypoints()
    {
        // ToDo: Find the child objects/transforms of the Transform called 'path'
        //      Store those in the List called 'waypoints'
        //      See Ch 9, p. 253
        
        foreach (Transform child in path)
        {
            waypoints.Add(child);
        }
        
    }

    /// <summary>
    /// In here the enemy moves continuously from waypoint to waypoint
    /// </summary>
    void Update()
    {
        // if there's no path, don't bother
        if (waypoints.Count == 0) return;
        
        // get the position of the current target
        Vector3 target = waypoints [pathIndex].position;
        // calculate the new position towards the target
        Vector3 newPos = Vector3.MoveTowards( transform.position, target, speed * Time.deltaTime );
    
        // apply position and rotation to this transform
        transform.position = newPos;
        transform.LookAt( target );

        // have I arrived? Pick next target in list
        if( Vector3.Distance( newPos, target ) == 0 )
        {
            pathIndex = ++pathIndex % waypoints.Count;
        }
    }
}
