using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class addBuilding : MonoBehaviour
{
    public GameObject mineralCollector, minerHouse, buildToAdd;

    private gameState game_state;

    [SerializeField]
    public int mineralCollectorCost, minerHouseCost;

    private Transform parentObject;

    public GameObject dialogue;
    public string[] line;

    //public bool buildMode;

    [SerializeField]
    public GameObject objectToHit;
    public float maxDistance = 100f;
    public int layerMask;
    public Vector2 boxSize = new Vector2(1, 1);  

    private void Start()
    {
        layerMask = Physics2D.AllLayers;
        game_state = GameObject.Find("GameManager").GetComponent<gameState>();
        parentObject = GameObject.Find("BuildingParentObject").GetComponent<Transform>();
    }

    public void onMineralCollectorBtn()
    {
        buildToAdd = mineralCollector;
        addBuild();
    }

    public void onMinerHouseBtn()
    {
        buildToAdd = minerHouse;
        addBuild();
    }


    private void addBuild()
    {
        if (buildToAdd == mineralCollector)
        {
            if (game_state.numberOfCoins >= mineralCollectorCost)
            {
                StartCoroutine(placeBuild());
            }
            else if (game_state.numberOfCoins < mineralCollectorCost)
            {
                line = new string[1];
                line[0] = "You dont have enough Coins";
                dialogue.SetActive(true);
                dialogue.GetComponent<Dialogue>().start_dialogue(line);
            }
        }
        if (buildToAdd == minerHouse)
        {
            if (game_state.numberOfCoins >= minerHouseCost)
            {
                StartCoroutine(placeBuild());
            }
            else if (game_state.numberOfCoins < minerHouseCost)
            {
                line = new string[1];
                line[0] = "You dont have enough Coins";
                dialogue.SetActive(true);
                dialogue.GetComponent<Dialogue>().start_dialogue(line);
            }
        }

    }

    private IEnumerator placeBuild()
    {
        yield return new WaitForSeconds(1.0f);

        yield return waitForKeyPress();
    }

    private IEnumerator waitForKeyPress()
    {
        bool pressed = false;
        while (!pressed)
        {
            if (Input.GetMouseButtonDown(1) || Input.touchCount > 0)
            {
                if (CheckIfHitSpecificObject())
                {
                    Vector2 position = Vector2.zero;
                    try
                    {
                        position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    }
                    catch
                    {
                        if(Input.GetTouch(0).phase == TouchPhase.Stationary)
                        {
                            position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                        }
                        
                    }
                    GameObject buildObject = Instantiate(buildToAdd, position, transform.rotation, parentObject);

                    if (buildToAdd == mineralCollector)
                    {
                        game_state.numberOfCoins -= mineralCollectorCost;
                        mineralCollectorCost += 250;
                    }
                    if (buildToAdd == minerHouse)
                    {
                        game_state.minerHouse.Add(buildObject);

                        game_state.numberOfCoins -= minerHouseCost;
                        minerHouseCost += 250;
                    }
                    
                }
                pressed = true;
            }
            yield return null;
        }
    }

    private bool CheckIfHitSpecificObject()
    {
        Ray ray;
        boxSize = (Vector2)buildToAdd.GetComponent<SpriteRenderer>().bounds.size;
        try
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        catch
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        }
        

        RaycastHit2D hit = Physics2D.BoxCast(ray.origin, boxSize, 0, ray.direction, maxDistance, layerMask);
        Debug.Log(hit.collider.name);
        if (hit.collider.gameObject == objectToHit)
        {
            
            Debug.Log(boxSize);
            return true;
        }
        return false;
    }
}
