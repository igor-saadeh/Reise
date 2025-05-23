using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


// Criar forma de resetar a barra de progressos?
public class ProgressBar : MonoBehaviour
{
    public static ProgressBar Instance { get; private set; } // necessario?
    public UnityEngine.UI.Slider slider;
    private bool isWatering = false;
    private float currentWateringTime = 0f;
    

    private void Awake()
    {
        Instance = this;
        slider = GetComponent<UnityEngine.UI.Slider>();

        GameEvents.OnWateringStart.AddListener(() =>
        {
            StartUpdatingProgressBar();
        });
        GameEvents.OnWateringStop.AddListener(() =>
        {
            StopUpdatingProgressBar();
        });
    }

    private void Update()
    {
        if (isWatering)
        {
            currentWateringTime += Time.deltaTime;
            float progress = currentWateringTime / 5f; // Calcula o progresso como uma porcentagem do tempo total de rega
            SetProgress(progress); // Atualiza visualmente o progresso da barra
            if (currentWateringTime >= 5f)
            {
                StopUpdatingProgressBar();
                HideProgressBar();
                GameEvents.OnMinigame2Finished.Invoke();    
                // ativar botao para proximo quadro // EventSystem
            }
        }
    }

    private void StartUpdatingProgressBar()
    {
        isWatering = true;
        ShowProgressBar();
        //currentWateringTime = 0f; // Reinicia o tempo de rega
        Debug.Log("ProgressBar started updating.");
    }

    private void StopUpdatingProgressBar()
    {
        isWatering = false;
        //HideProgressBar();
        Debug.Log("ProgressBar stopped updating.");
    }

    public void ShowProgressBar()
    {
        gameObject.SetActive(true);
        slider.value = 0f; // Reinicia o valor da barra para zero // precisa?
    }

    public void HideProgressBar()
    {
        gameObject.SetActive(false);
    }

    public void SetProgress(float progress)
    {
        slider.value = progress; // Define o valor da barra de acordo com o progresso recebido
    }
}
