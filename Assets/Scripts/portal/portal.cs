using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            animator.SetTrigger("close");
        }
    }

    public void closeAnimationFinish()
    {
        gameObject.SetActive(false);
        SceneManager.LoadSceneAsync(1);
    }
}
