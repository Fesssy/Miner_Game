using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSignPost : MonoBehaviour
{
    public bool hasKey;
    private string[] lines;
    public bool visited;

    public GameObject FlashDialogue;
    public GameObject Dialogue;

    public GameObject openedGate;
    public GameObject closedGate;

    private void Start()
    {
        hasKey = false;
        lines = new string[1];
        visited = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (hasKey && closedGate.activeInHierarchy)
            {
                FlashDialogue.SetActive(true);
                FlashDialogue.GetComponent<flashDialogue>().start_dialogue("Opening the Door .....");
                openDoor();
            }
            else
            {
                lines[0] = "You need the key to open the door. Find it by following the rabbits.";
                Dialogue.SetActive(true);
                Dialogue.GetComponent<Dialogue>().start_dialogue(lines);
            }
        }
    }

    void openDoor()
    {
        closedGate.SetActive(false);
        openedGate.SetActive(true);
    }

}
