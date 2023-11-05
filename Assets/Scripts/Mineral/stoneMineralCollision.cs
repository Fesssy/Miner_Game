using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneMineralCollision : MonoBehaviour
{
    //private spawnMinerals _spawnMinerals;
    private gameState game_state;

    void Start()
    {
        game_state = GameObject.Find("GameManager").GetComponent<gameState>();
        //_spawnMinerals = GameObject.FindObjectOfType<spawnMinerals>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("StoneMiner") && !other.GetComponent<depositStoneMineral>().depositmineral))
        {

            foreach (var item in game_state.stonemineral)
            {
                if (item == gameObject)
                {
                    game_state.stonemineral.Remove(item);
                    break;
                }

            }

        }
    }
}
