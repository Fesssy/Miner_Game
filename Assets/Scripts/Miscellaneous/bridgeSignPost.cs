using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class bridgeSignPost : MonoBehaviour
{
    public bool hasStones;
    private string[] lines;
    public bool visited;

    public GameObject Dialogue;
    public GameObject flashDialogue;
    public GameObject bridge;
    public gameState game_state;

    private void Start()
    {
        lines = new string[1];
        visited = false;
        game_state = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameState>();
    }

    private void Update()
    {
        if (game_state.numberOfStone >= 16 && game_state.numberOfCoins >= 2000)
            hasStones = true;
        else
            hasStones = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (hasStones && !bridge.GetComponent<TilemapRenderer>().enabled)
            {
                game_state.numberOfStone -= 16;
                game_state.numberOfCoins -= 1500;
                buildBridge();
                flashDialogue.SetActive(true);
                flashDialogue.GetComponent<flashDialogue>().start_dialogue("Building the bridge ....");
            }
            else
            {
                lines[0] = "You need to mine 16 stones and have 1500 coins rebuild the bridge to travel to the portal.";
                Dialogue.SetActive(true);
                Dialogue.GetComponent<Dialogue>().start_dialogue(lines);
            }
        }
    }

    void buildBridge()
    {
        bridge.GetComponent<TilemapRenderer>().enabled = true;
        bridge.GetComponent<EdgeCollider2D>().enabled = false;
    }

}
