using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    private UnityEngine.UI.Button nextButton;

    private void Awake()
    {
        //nextButton = GetComponent<UnityEngine.UI.Button>();

        nextButton = GetComponentInChildren<UnityEngine.UI.Button>();
        Debug.Log($"Componente pego: {nextButton.name}");

        GameEvents.OnMinigame2Finished.AddListener(() =>
        {
            EnableButton();
        });
    }

    private void EnableButton()
    {
        nextButton.enabled = true;
    }

}
