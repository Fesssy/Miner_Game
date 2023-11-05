using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seaCollision : MonoBehaviour
{
    public GameObject FlashDialogue;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sea") || collision.gameObject.CompareTag("Bridge"))
        {
            FlashDialogue.SetActive(true);
            FlashDialogue.GetComponent<flashDialogue>().start_dialogue("You fell in sea.");
            Debug.Log("Collided with Sea");
            GetComponent<headMinerMovement>().setPosition(Vector2.one);
        }
    }
}
