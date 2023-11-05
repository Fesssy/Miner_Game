using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private string[] line;
    public GameObject dialogue;
    public gameState game_state;

    private bool firstrabbit;
    private bool firstminer;
    void Start()
    {
        firstrabbit = false;
        firstminer = false;
        game_state = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameState>();
        start();
    }

    private void Update()
    {
        if (game_state.rabbit.Count == 1 && firstrabbit)
        {
            firstrabbit = false;
            line = new string[1];
            line[0] = "Just a heads up. Rabbit does nothing but liven up the environment. But hey, they are enrgetic.";
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().start_dialogue(line);
        }
        if (game_state.numberOfMiner == 1 && firstminer)
        {
            firstminer = false;
            line = new string[4];
            line[0] = "Added Miner can automatically move towards minerals and start mining. It takes 10 seconds to mine one mineral.";
            line[1] = "Dont worry, you can decrease this time as well as increase the miner's speed by buying the spels. " +
                "You can see it below ...";
            line[2] = "By the way miner can only carry 10 minerals at a time, that need to be deposited through Mineral Collector. " +
                "You can see it in the right bottom corner.";
            line[3] = "And yeah they rest as well from time to time.";
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().start_dialogue(line);
        }
    }

    private void start()
    {
        line = new string[4];
        line[0] = "HHey gamer!! Welcome to my game 'Miner Idle Game'";
        line[1] = "Its a very simple game, where you need to just collect the minerals and increase your miner army.";
        line[2] = "If you see on the top, you can see number of miners you have added.";
        line[3] = "But you need money to add miner, and for money, you need to collect minerals";
        dialogue.SetActive(true);
        dialogue.GetComponent<Dialogue>().start_dialogue(line);
    }
}
