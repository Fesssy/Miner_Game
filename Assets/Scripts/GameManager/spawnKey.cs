using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnKey : MonoBehaviour
{
    public GameObject key;

    private gameState game_state;

    private Transform parentObject;

    private int rabbitNumber;

    [SerializeField]
    float spawnTimeInterval, despawnTime, nextSpawnTime;
    bool canSpawn;


    void Start()
    {
        game_state = GameObject.Find("GameManager").GetComponent<gameState>();
        parentObject = GameObject.Find("MineralParentObject").GetComponent<Transform>();
        canSpawn = true;
        spawnTimeInterval = Random.Range(10.0f, 15.0f);
        nextSpawnTime = Time.time + spawnTimeInterval;
    }

    void Update()
    {
        rabbitNumber = game_state.rabbit.Count;

        if(Time.time > nextSpawnTime && canSpawn && rabbitNumber > 0)
        {
            key.SetActive(true);
            key.transform.position = getRandomPosition();
            canSpawn = false;
            despawnTime = Random.Range(5.0f, 15.0f);
            StartCoroutine(despawn());
        }

        //Debug.Log("Countdown: " + countdown + "Limit: " + limit);
    }

    IEnumerator despawn()
    {
        yield return new WaitForSeconds(despawnTime);
        spawnTimeInterval = Random.Range(10.0f, 15.0f);
        nextSpawnTime = Time.time + spawnTimeInterval;
        key.SetActive(false);
        canSpawn = true;

    }

    private Vector3 getRandomPosition()
    {

        /*
         * Need to add logic for checking objects before spawning.
         */

        float x, y;

        x = Random.Range(-25, 25);
        y = Random.Range(-15, 15);

        return new Vector3(x, y, 0);

    }

}
