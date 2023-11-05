using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene2 : MonoBehaviour
{
    public Animator animator;
    public GameObject portal;
    public GameObject player;

    void Start()
    {
        StartCoroutine(closePortal());
    }

    private IEnumerator closePortal()
    {
        portal.SetActive(true);
        animator.ResetTrigger("close");
        yield return new WaitForSeconds(1);
        player.SetActive(true);
        yield return new WaitForSeconds(2);
        animator.SetTrigger("close");
    }

}
