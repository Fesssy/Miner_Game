using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class depositStoneMineral : MonoBehaviour
{
    public bool depositmineral;

    private gameState game_state;

    private collectingStoneMineral _collectingMineral;

    private stoneminerMovement _minerMovement;

    void Start()
    {
        depositmineral = false;
        game_state = GameObject.Find("GameManager").GetComponent<gameState>();
        _collectingMineral = GetComponent<collectingStoneMineral>();
        _minerMovement = GetComponent<stoneminerMovement>();
    }

    // Update is called once per frame
    /*void /Update()
    {
        if(depositmineral)
        {
            if(transform.position.x < 4 && transform.position.y < 4 && transform.position.x > -4 && transform.position.y > -4)
            {
                game_state.numberOfCoins += 100;
                _collectingMineral.minerals = 0;
                depositmineral = false;
            }
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("MineralCollector") && depositmineral)
        {
            game_state.numberOfStone += _collectingMineral.minerals;
            _collectingMineral.minerals = 0;
            depositmineral = false;
        }
    }
}
