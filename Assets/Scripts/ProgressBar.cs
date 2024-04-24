using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public static ProgressBar Instance { get; private set; }
    public Slider slider;

    private void Awake()
    {
        Instance = this;
        slider.gameObject.SetActive(false);
    }

    public void ShowProgressBar()
    {
        slider.gameObject.SetActive(true);
        slider.value = 0f; // Reinicia o valor da barra para zero
    }

    public void HideProgressBar()
    {
        slider.gameObject.SetActive(false);
    }

    public void SetProgress(float progress)
    {
        slider.value = progress; // Define o valor da barra de acordo com o progresso recebido
    }
}
