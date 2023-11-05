using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCollision : MonoBehaviour
{
    [SerializeField]
    public GameObject post;
    public GameObject keyText;
    public GameObject key;
    public GameObject spawnKey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            post.GetComponent<doorSignPost>().hasKey = true;
            keyText.SetActive(true);
            key.SetActive(false);
            spawnKey.SetActive(false);
        }
    }
}
