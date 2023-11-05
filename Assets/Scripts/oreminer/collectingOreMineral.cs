using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectingOreMineral : MonoBehaviour
{
    public int minerals;

    public int maxminerals;

    private depositOreMineral _depositMineral;

    public Animator animator;

    private float collectingTime;

    private spawnMinerals _spawnMinerals;

    private gameState gs;

    private void Awake()
    {
        minerals = 0;
        maxminerals = 3;
        _depositMineral = GameObject.FindObjectOfType<depositOreMineral>();
        _spawnMinerals = GameObject.FindObjectOfType<spawnMinerals>();
        gs = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameState>();
    }

    private void Update()
    {
        collectingTime = gs.oremineralCollectingTime;

        if (minerals >= maxminerals)
        {
            _depositMineral.depositmineral = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (minerals != maxminerals && other.CompareTag("OreMineral"))
        {
            StartCoroutine(collect(other.gameObject));
        }

    }

    IEnumerator collect(GameObject other)
    {

        yield return new WaitForSecondsRealtime(collectingTime);

        Destroy(other.gameObject);
        minerals++;

        _spawnMinerals.oreLimit++;
    }




}
