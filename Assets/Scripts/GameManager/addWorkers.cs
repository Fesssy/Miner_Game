using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addWorkers : MonoBehaviour
{
    public GameObject miner;
    public GameObject stoneminer;
    public GameObject oreminer;
    public GameObject rabbit;

    public GameObject dialogue;
    public string[] line;

    private gameState game_state;
    [SerializeField]
    public int cost;
    public int stoneCost;
    public int oreCost;
    public int maxMiner;
    private Transform parentObject;

    private void Start() {
        game_state = GameObject.Find("GameManager").GetComponent<gameState>();
        parentObject = GameObject.Find("MinerParentObject").GetComponent<Transform>();
    }

    public void addMiner()
    {
        if (game_state.numberOfCoins >= cost && (game_state.minerHouse.Count * 3) > game_state.numberOfMiner)
        {
            GameObject minerObject = Instantiate(miner, parentObject.position, transform.rotation, parentObject);
            game_state.miner.Add(minerObject);
            game_state.numberOfCoins -= cost;
            cost += 250;
        }
        else if (game_state.numberOfCoins < cost)
        {
            line = new string[1];
            line[0] = "You dont have enough Coins";
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().start_dialogue(line);
        }
        else if (game_state.minerHouse.Count == 0)
        {
            line = new string[2];
            line[0] = "It seems you have collected enough minerals, but miner needs a house to rest in ..... ";
            line[1] = "Before adding a miner, create a Miner House";
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().start_dialogue(line);
        }
        else if ((game_state.minerHouse.Count * 3) == game_state.numberOfMiner)
        {
            line = new string[1];
            line[0] = "One House can only accomodate 3 Miner";
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().start_dialogue(line);
        }
        

    }

    public void addStoneMiner()
    {
        if (game_state.numberOfCoins >= stoneCost && (game_state.minerHouse.Count * 3) > game_state.numberOfMiner)
        {
            GameObject minerObject = Instantiate(stoneminer, parentObject.position, transform.rotation, parentObject);
            game_state.stoneminer.Add(minerObject);
            game_state.numberOfCoins -= cost;
            stoneCost += 250;
        }
        else if (game_state.numberOfCoins < stoneCost)
        {
            line = new string[1];
            line[0] = "You dont have enough Coins";
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().start_dialogue(line);
        }
        else if (game_state.minerHouse.Count == 0)
        {
            line = new string[2];
            line[0] = "It seems you have collected enough minerals, but miner needs a house to rest in ..... ";
            line[1] = "Before adding a miner, create a Miner House";
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().start_dialogue(line);
        }
        else if ((game_state.minerHouse.Count * 3) == game_state.numberOfMiner)
        {
            line = new string[1];
            line[0] = "One House can only accomodate 3 Miner";
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().start_dialogue(line);
        }


    }

    public void addOreMiner()
    {
        if (game_state.numberOfCoins >= oreCost && (game_state.minerHouse.Count * 3) > game_state.numberOfMiner)
        {
            GameObject minerObject = Instantiate(oreminer, parentObject.position, transform.rotation, parentObject);
            game_state.oreminer.Add(minerObject);
            game_state.numberOfCoins -= oreCost;
            oreCost += 250;
        }
        else if (game_state.numberOfCoins < stoneCost)
        {
            line = new string[1];
            line[0] = "You dont have enough Coins";
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().start_dialogue(line);
        }
        else if (game_state.minerHouse.Count == 0)
        {
            line = new string[2];
            line[0] = "It seems you have collected enough minerals, but miner needs a house to rest in ..... ";
            line[1] = "Before adding a miner, create a Miner House";
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().start_dialogue(line);
        }
        else if ((game_state.minerHouse.Count * 3) == game_state.numberOfMiner)
        {
            line = new string[1];
            line[0] = "One House can only accomodate 3 Miner";
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().start_dialogue(line);
        }


    }

    public void addRabbit()
    {
        if (game_state.numberOfCoins >= 50 && game_state.minerHouse.Count > game_state.rabbit.Count)
        {
            GameObject rabbitObject = Instantiate(rabbit, parentObject.position, transform.rotation, parentObject);
            game_state.rabbit.Add(rabbitObject);
            game_state.numberOfCoins -= 50;
        }
        else if (game_state.numberOfCoins < 50)
        {
            line = new string[1];
            line[0] = "You dont have enough Coins";
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().start_dialogue(line);
        }
        else if (game_state.minerHouse.Count == 0)
        {
            line = new string[1];
            line[0] = "Ooh! You like rabbits, me too! But you cant add rabbit before you add the House.";
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().start_dialogue(line);
        }
        else if (game_state.minerHouse.Count == game_state.rabbit.Count)
        {
            line = new string[1];
            line[0] = "One House can only accomodate 1 Rabbit.";
            dialogue.SetActive(true);
            dialogue.GetComponent<Dialogue>().start_dialogue(line);
        }

    }
}
