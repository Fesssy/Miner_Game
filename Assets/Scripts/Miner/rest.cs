using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rest : MonoBehaviour
{
    public enum currentState
    {
        wantRest,
        resting,
        restCompleted
    }

    public currentState state;

    private Vector2 minerPosition, homePosition;

    private float restingTime, workingTime;

    private gameState game_state;

    void Start()
    {
        restingTime = 10.0f;
        workingTime = 150.0f;
        state = currentState.restCompleted;
        minerPosition = transform.position;
        game_state = GameObject.Find("GameManager").GetComponent<gameState>();

        StartCoroutine(work());
    }

    void Update()
    {
        minerPosition = transform.position;

        if (state == currentState.wantRest)
            restingPlace();

        _display();
    }

    private void _display()
    {
        
    }

    private IEnumerator work()
    {
        yield return new WaitForSeconds(workingTime);
        state = currentState.wantRest;
    }

    private void restingPlace()
    {
        try
        {
            findNearestHouse();
            Debug.Log("rest: " + homePosition);
        }
        catch
        {
            Debug.Log("rest - Miner is tired, needs to rest");
        }
        if ((minerPosition.x < homePosition.x + 2 && minerPosition.x > homePosition.x - 2) && (minerPosition.y < homePosition.y + 2 && minerPosition.y > homePosition.y - 2))
        {
            state = currentState.resting;
            StartCoroutine(sleep());
        }
    }

    private void findNearestHouse()
    {
        Vector2 path;
        Vector2 differenceInPath;

        List<GameObject> allHouse = game_state.minerHouse;
        Transform[] allHousePositions = new Transform[allHouse.Count];

        for (int i = 0; i < allHouse.Count; i++)
        {
            allHousePositions[i] = allHouse[i].transform;
            Debug.Log(allHousePositions[i].position);
            Debug.Log(allHouse[i].transform.position);
        }

        path = allHousePositions[0].position;
        homePosition = path;
        foreach (Transform house in allHousePositions)
        {
            differenceInPath = house.position - transform.position;
            if (differenceInPath.magnitude < path.magnitude)
            {
                path = differenceInPath;
                homePosition = house.position;
            }
        }
    }

    private IEnumerator sleep()
    {
        yield return new WaitForSeconds(restingTime);
        state = currentState.restCompleted;
        StartCoroutine(work());
    }

    public Vector2 getHomePosition()
    {
        return homePosition;
    }
}
