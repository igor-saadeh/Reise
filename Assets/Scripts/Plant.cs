using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour, IWaterable
{
    private bool beingWatered = false;

    public void StartWatering()
    {
        beingWatered = true;
        Debug.Log("A planta est� sendo regada.");
    }

    public void StopWatering()
    {
        beingWatered = false;
        Debug.Log("A planta n�o est� mais sendo regada.");
    }
}

