using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineralCollision : MonoBehaviour
{
    private spawnMinerals _spawnMinerals;
    private gameState game_state;

    void Start()
    {
        game_state = GameObject.Find("GameManager").GetComponent<gameState>();
        _spawnMinerals = GameObject.FindObjectOfType<spawnMinerals>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Miner") && !other.GetComponent<depositMineral>().depositmineral) || other.CompareTag("Player"))
        {
            if (other.CompareTag("Player"))
            {
                game_state.numberOfCoins += 10;
                Destroy(gameObject);
                _spawnMinerals.limit++;
            }
              
            foreach (var item in game_state.mineral)
            {
                if (item == gameObject)
                {
                    game_state.mineral.Remove(item);
                    break;
                }
                    
            }

        }
    }
}
