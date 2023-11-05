using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalSignPost : MonoBehaviour
{
    public bool hasOres;
    private string[] lines;
    public bool visited;

    public GameObject Dialogue;
    public GameObject flashDialogue;
    public GameObject portal;
    public gameState game_state;

    private void Start()
    {
        lines = new string[1];
        visited = false;
        game_state = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameState>();
    }

    private void Update()
    {
        if (game_state.numberOfStone >= 15 && game_state.numberOfOre >= 10 && game_state.numberOfCoins >= 2000)
            hasOres = true;
        else
            hasOres = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (hasOres)
            {
                game_state.numberOfStone -= 15;
                game_state.numberOfOre -= 10;
                game_state.numberOfCoins -= 2000;
                flashDialogue.SetActive(true);
                flashDialogue.GetComponent<flashDialogue>().start_dialogue("Building the portal ....");
                buildPortal();
            }
            else
            {
                lines[0] = "You need to gather 10 purple ores and 15 stones to build the portal and leave.";
                Dialogue.SetActive(true);
                Dialogue.GetComponent<Dialogue>().start_dialogue(lines);
            }
        }
    }

    void buildPortal()
    {
        portal.SetActive(true);
        portal.GetComponent<Animator>().ResetTrigger("close");
    }

}
