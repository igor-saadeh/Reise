using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonM4 : MonoBehaviour
{
    private UnityEngine.UI.Button nextButton;

    private void Awake()
    {
        //nextButton = GetComponent<UnityEngine.UI.Button>();

        nextButton = GetComponentInChildren<UnityEngine.UI.Button>();
        Debug.Log($"Componente pego: {nextButton.name}");

        GameEvents.OnMinigame4Finished.AddListener(() =>
        {
            EnableButton();
        });
    }

    private void EnableButton()
    {
        if (nextButton.enabled == false)
        {
            nextButton.enabled = true;
        }
    }

}

