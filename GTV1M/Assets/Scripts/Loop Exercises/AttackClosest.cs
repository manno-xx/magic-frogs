using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackClosest : MonoBehaviour
{
    private GameObject victim;

    private float speed = 4;

    // Start is called before the first frame update
    void Start()
    {
        // find all game objects with tag 'Player'
        GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");

        victim = FindNearest(allPlayers);
    }

    /// <summary>
    /// ToDo: write the code that is described in 'pseudo code'
    /// ToDo: Can you also find a solution that uses Linq?
    ///       That is way less code, but the first exercise (maybe) makes your brain work harder :) 
    /// </summary>
    /// <param name="gameObjects"></param>
    /// <returns></returns>
    private GameObject FindNearest(GameObject[] gameObjects)
    {
        GameObject closest = gameObjects[0];
        float smallestDistance = float.MaxValue;
        
        // Loop through the list of gameobjects
        foreach (GameObject target in gameObjects)
        {
            // calculate distance to current item in the list
            // https://docs.unity3d.com/ScriptReference/Vector3.Distance.html
            float distance = Vector3.Distance(transform.position, target.transform.position);

            // if that distance is smaller than last smallest distance, we have one that is closer
            //      store that game object in the variable 'closest'
            //      update the variable smallestDistance to contain the smallest distance just calculated
            if (distance < smallestDistance)
            {
                closest = target;
                smallestDistance = distance;
            }
        }
        // return the one that seems to be closest
        return closest;
    }


    /// <summary>
    /// Move towards the closest player
    /// </summary>
    void Update()
    {
        Vector3 target = victim.transform.position;
        // calculate the new position towards the target
        Vector3 newPos = Vector3.MoveTowards( transform.position, target, speed * Time.deltaTime );
    
        // apply position and rotation to this transform
        transform.position = newPos;
        transform.LookAt( target );
    }
}
