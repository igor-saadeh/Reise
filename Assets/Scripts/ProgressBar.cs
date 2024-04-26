using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ProgressBar : MonoBehaviour
{
    public static ProgressBar Instance { get; private set; }
    //public UnityEngine.UI.Slider slider;

    private void Awake()
    {
        Instance = this;
        //gameObject.SetActive(false);
    }

    public void ShowProgressBar()
    {
        //slider.gameObject.SetActive(true);
        gameObject.SetActive(true);
        //slider.value = 0f; // Reinicia o valor da barra para zero
        GetComponent<UnityEngine.UI.Slider>().value = 0f;
    }

    public void HideProgressBar()
    {
        gameObject.SetActive(false);
    }

    // VN
    public void SetProgress(float progress)
    {
        GetComponent<UnityEngine.UI.Slider>().value = progress; // Define o valor da barra de acordo com o progresso recebido
    }
}
