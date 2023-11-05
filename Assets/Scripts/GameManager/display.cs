using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class display : MonoBehaviour
{
    private gameState gs;
    private addWorkers aw;
    private addBuilding ab;

    [SerializeField]
    private TMP_Text coinsText;
    [SerializeField]
    private TMP_Text minersnumberText;
    [SerializeField]
    private TMP_Text stonenumberText;
    [SerializeField]
    private TMP_Text orenumberText;
    [SerializeField]
    private TMP_Text extractionspeedText;
    [SerializeField]
    private TMP_Text minerCostText;
    [SerializeField]
    private TMP_Text stoneminerCostText;
    [SerializeField]
    private TMP_Text oreminerCostText;
    [SerializeField]
    private TMP_Text rabbitCostText;
    [SerializeField]
    private TMP_Text speedScrollCostText;
    [SerializeField]
    private TMP_Text collectingTimeScrollCostText;
    [SerializeField]
    private TMP_Text mineralCollectorText;
    [SerializeField]
    private TMP_Text minerHouseCostText;



    void Start()
    {
        gs = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameState>();
        aw = GameObject.FindGameObjectWithTag("GameController").GetComponent<addWorkers>();
        ab = GameObject.FindGameObjectWithTag("GameController").GetComponent<addBuilding>();
    }

    // Update is called once per frame
    void Update()
    {
        double extractionSpeed = gs.numberOfMiner / gs.mineralCollectingTime;
        coinsText.SetText(gs.numberOfCoins.ToString());
        minersnumberText.SetText(gs.numberOfMiner + "/" + (gs.minerHouse.Count * 3));
        stonenumberText.SetText(gs.numberOfStone.ToString());
        orenumberText.SetText(gs.numberOfOre.ToString());
        extractionspeedText.SetText(Math.Round(extractionSpeed, 1).ToString());
        minerCostText.SetText(aw.cost.ToString());
        stoneminerCostText.SetText(aw.stoneCost.ToString());
        oreminerCostText.SetText(aw.oreCost.ToString());
        rabbitCostText.SetText("50");
        speedScrollCostText.SetText(gs.minerSpeedCost.ToString());
        collectingTimeScrollCostText.SetText(gs.collectingTimeCost.ToString());
        mineralCollectorText.SetText(ab.mineralCollectorCost.ToString());
        minerHouseCostText.SetText(ab.minerHouseCost.ToString());
    }
}
