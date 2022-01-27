using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayText;

    public void Start()
    {
        displayText.enabled = false;
    }
    

    public void ShowText(string text,float showLength)
    {
        StartCoroutine(ShowTextCoroutine(text, showLength));
    }

    private IEnumerator ShowTextCoroutine(string text, float showLength)
    {
        displayText.enabled = true;
        displayText.text = text;
        yield return new WaitForSeconds(showLength);
        displayText.text = "";
        displayText.enabled = false;
    }

    public void FlashText(string text, float displayLength, float flashLength)
    {
        StartCoroutine(FlashTextCoroutine(text, displayLength, flashLength));
    }

    private IEnumerator FlashTextCoroutine(string text, float displayLength, float flashLength)
    {
        bool isOn = true;
        displayText.text = text;
        for (float f = 0.0f; f <= 0;)
        {
            displayText.enabled = isOn;
            isOn = !isOn;
            yield return new WaitForSeconds(flashLength);
            f -= flashLength;
        }
        displayText.text = "";
        displayText.enabled = false;
    }
}
