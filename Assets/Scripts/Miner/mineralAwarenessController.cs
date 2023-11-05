using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineralAwarenessController : MonoBehaviour
{
    public bool awareOfMineral{get; private set;}

    public Vector2 directionToMineral {get; private set;}

    private Transform _mineral;

    private gameState game_state;

    void Start()
    {
        game_state = GameObject.Find("GameManager").GetComponent<gameState>();
        findNearestMineral();
    }

    void Update()
    {
        try
        {

            directionToMineral = _mineral.position;

            awareOfMineral = true;
            
        }
        catch (System.Exception)
        {
            try
            {
                findNearestMineral();
                directionToMineral = _mineral.position;
            }
            catch(System.Exception)
            {
                awareOfMineral = false;
            }
             
        }   

    }

    private void findNearestMineral()
    {
        Vector2 path;
        Vector2 differenceInPath;

        List<GameObject> allminerals = game_state.mineral;
        Transform[] allMineralPositions = new Transform[allminerals.Count];

        for (int i = 0; i < allminerals.Count; i++)
        {
            allMineralPositions[i] = allminerals[i].transform;
        }

        path = allMineralPositions[0].position - transform.position;
        foreach (Transform mineral in allMineralPositions)
        {
            differenceInPath = mineral.position - transform.position;
            if(differenceInPath.magnitude < path.magnitude)
            {
                path = differenceInPath;
                _mineral = mineral;
            }
        }
        
    }

}
