using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private List<GameObject> enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();

        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        // todo: Write a loop that instantiates 10 new instances of the enemyPrefab.
        //       Make small steps. Do not implement all requirements in the first attempt if you find this hard
        //       Make it so that the instantiated game objects do not appear at one and the same place
        //          You _can_ use the loop counter (usually called 'i') to set the position on one of the three axis
        //       Add the newly instantiated enemy to the list with the name 'enemies'
        //          This could be useful for further processing of the game objects generated
        // Loop: Ch 4, p. 98
        // Instantiate: Ch 8, p. 215 or https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
        // Adding to list: Ch 4, p. 93 

        for (int i = 0; i < 300; i++)
        {
            Instantiate(enemyPrefab, GetNicePosition(), Quaternion.identity, transform);
        }
    }

    Vector3 GetNicePosition()
    {
        return Random.onUnitSphere * 20;
    }
}
