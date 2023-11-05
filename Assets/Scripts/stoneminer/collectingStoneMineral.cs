using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectingStoneMineral : MonoBehaviour
{
    public int minerals;

    public int maxminerals;

    private depositStoneMineral _depositMineral;

    public Animator animator;

    private float collectingTime;

    private spawnMinerals _spawnMinerals;

    private gameState gs;

    private void Awake()
    {
        minerals = 0;
        maxminerals = 3;
        _depositMineral = GameObject.FindObjectOfType<depositStoneMineral>();
        _spawnMinerals = GameObject.FindObjectOfType<spawnMinerals>();
        gs = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameState>();
    }

    private void Update()
    {
        collectingTime = gs.stonemineralCollectingTime;

        if (minerals >= maxminerals)
        {
            _depositMineral.depositmineral = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (minerals != maxminerals && other.CompareTag("StoneMineral"))
        {
            StartCoroutine(collect(other.gameObject));
        }

    }

    IEnumerator collect(GameObject other)
    {

        yield return new WaitForSecondsRealtime(collectingTime);

        Destroy(other.gameObject);
        minerals++;

        _spawnMinerals.stoneLimit++;
    }




}
