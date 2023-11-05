using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class flashDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string lines;

    void Start()
    {
        textComponent.text = string.Empty;
    }

    public void start_dialogue(string sentence)
    {
        StopAllCoroutines();
        lines = sentence;
        textComponent.text = string.Empty;
        StartCoroutine(StartDialogue());
    }

    IEnumerator StartDialogue()
    {
        textComponent.text = lines;
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

}
