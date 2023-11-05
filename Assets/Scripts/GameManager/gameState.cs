using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameState : MonoBehaviour
{
    [SerializeField]
    public int numberOfMiner;
    public int numberOfCoins;
    public int numberOfStone;
    public int numberOfOre;

    public float minerSpeed;
    public float stoneminerSpeed;
    public float oreminerSpeed;

    public float mineralCollectingTime;
    public float stonemineralCollectingTime;
    public float oremineralCollectingTime;

    public int minerSpeedCost;
    public int collectingTimeCost;

    public float speedFactor;

    public bool hasKey;

    public List<GameObject> miner;
    public List<GameObject> stoneminer;
    public List<GameObject> oreminer;

    public List<GameObject> mineral;
    public List<GameObject> stonemineral;
    public List<GameObject> oremineral;

    public List<GameObject> minerHouse;

    public List<GameObject> building;

    public List<GameObject> rabbit;

    private void Start()
    {
        numberOfMiner = 0;
        numberOfCoins = 0;

        numberOfStone = 0;
        numberOfOre = 0;

        speedFactor = 1.0f;

        hasKey = false; 

        minerSpeed = 1.5f;
        stoneminerSpeed = 1.0f;
        oreminerSpeed = 0.5f;

        mineralCollectingTime = 5.0f;
        stonemineralCollectingTime = 6.0f;
        oremineralCollectingTime = 7.0f;

        minerSpeedCost = 250;
        collectingTimeCost = 350;
    }

    private void Update()
    {
        numberOfMiner = miner.Count + stoneminer.Count + oreminer.Count;
    }

    public void increaseSpeed()
    {
        if (numberOfCoins >= minerSpeedCost)
        {
            minerSpeed+=0.5f;
            stoneminerSpeed = minerSpeed - 0.5f;
            oreminerSpeed = stoneminerSpeed - 0.5f;
            numberOfCoins -= minerSpeedCost;
            minerSpeedCost += (int)(minerSpeedCost*0.5);
        }
    }

    public void decreaseCollectingTime()
    {
        if (numberOfCoins >= collectingTimeCost)
        {
            speedFactor -= 0.1f;
            mineralCollectingTime *= speedFactor;
            stonemineralCollectingTime = mineralCollectingTime+1.0f;
            oremineralCollectingTime =stonemineralCollectingTime+1.0f;
            numberOfCoins -= collectingTimeCost;
            collectingTimeCost += (int)(collectingTimeCost * 0.5);
        }
    }

}
