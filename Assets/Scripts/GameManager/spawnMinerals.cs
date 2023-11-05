using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMinerals : MonoBehaviour
{
    public GameObject mineral, stonemineral, oremineral;

    private gameState game_state;

    private Transform parentObject;

    [SerializeField]
    float waitingtime, countdown;

    public int limit, stoneLimit, oreLimit;


    void Start()
    {
        game_state = GameObject.Find("GameManager").GetComponent<gameState>();
        parentObject = GameObject.Find("MineralParentObject").GetComponent<Transform>();
    }

    void Update()
    {
        if (countdown != 0)
            countdown--;

        else if (countdown == 0)
        {
            if (limit != 0)
                spawnMineral();
            if (stoneLimit != 0)
                spawnstoneMineral();
            if (oreLimit != 0)
                spawnoreMineral();

            countdown = waitingtime;
        }

        //Debug.Log("Countdown: " + countdown + "Limit: " + limit);
    }

    private void spawnMineral()
    {
        Vector3 randomPosition = getRandomPosition();
        GameObject mineralObject = Instantiate(mineral, randomPosition, Quaternion.identity, parentObject);
        game_state.mineral.Add(mineralObject);
        
        limit--;
    }

    private void spawnstoneMineral()
    {
        Vector3 randomPosition = getRandomPosition();
        GameObject mineralObject = Instantiate(stonemineral, randomPosition, Quaternion.identity, parentObject);
        game_state.stonemineral.Add(mineralObject);

        stoneLimit--;
    }

    private void spawnoreMineral()
    {
        Vector3 randomPosition = getRandomPosition();
        GameObject mineralObject = Instantiate(oremineral, randomPosition, Quaternion.identity, parentObject);
        game_state.oremineral.Add(mineralObject);

        oreLimit--;
    }

    private Vector3 getRandomPosition()
    {

        /*
         * Need to add logic for checking objects before spawning.
         */

        float x, y;

        x = Random.Range(-20, 20);
        y = Random.Range(-10, 10);

        return new Vector3(x, y, 0);

    }
}
