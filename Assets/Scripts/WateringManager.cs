using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WateringManager : MonoBehaviour
{
    public static WateringManager Instance { get; private set; }

    private bool isWatering = false;
    private float currentWateringTime = 0f;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (isWatering)
        {
            currentWateringTime += Time.deltaTime;
            float progress = currentWateringTime / 5f; // Calcula o progresso como uma porcentagem do tempo total de rega
            ProgressBar.Instance.SetProgress(progress); // Atualiza visualmente o progresso da barra
            if (currentWateringTime >= 5f)
            {
                FinishWatering();
            }
        }
    }

    public void StartWatering()
    {
        isWatering = true;
        ProgressBar.Instance.ShowProgressBar(); // Mostra a barra de progresso ao iniciar a rega
    }

    private void FinishWatering()
    {
        isWatering = false;
        currentWateringTime = 0f;
        ProgressBar.Instance.HideProgressBar(); // Esconde a barra de progresso ao terminar a rega
    }
}

