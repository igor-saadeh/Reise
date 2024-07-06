using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonM1 : MonoBehaviour
{
    private UnityEngine.UI.Button nextButton;

    private void Awake()
    {
        //nextButton = GetComponent<UnityEngine.UI.Button>();

        nextButton = GetComponentInChildren<UnityEngine.UI.Button>();
        Debug.Log($"Componente pego: {nextButton.name}");

        GameEvents.OnMinigame1Finished.AddListener(() =>
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
