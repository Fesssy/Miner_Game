using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purpleMineralCollision : MonoBehaviour
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
        if ((other.CompareTag("OreMiner") && !other.GetComponent<depositOreMineral>().depositmineral))
        {

            foreach (var item in game_state.oremineral)
            {
                if (item == gameObject)
                {
                    game_state.oremineral.Remove(item);
                    break;
                }

            }

        }
    }
}
