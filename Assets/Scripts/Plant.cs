using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour, IWaterable
{
    private bool beingWatered = false;

    public void StartWatering()
    {
        beingWatered = true;
        Debug.Log("A planta está sendo regada.");
    }

    public void StopWatering()
    {
        beingWatered = false;
        Debug.Log("A planta não está mais sendo regada.");
    }
}

