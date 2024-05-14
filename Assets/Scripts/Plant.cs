using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour, IWaterable
{
    //private bool beingWatered = false;

    private void Awake()
    {
        GameEvents.OnWateringStart.AddListener(StartWateringEventListener);
        GameEvents.OnWateringStop.AddListener(StopWateringEventListener);
    }

    public void StartWateringEventListener()
    {
        //beingWatered = true;
        Debug.Log("A planta está sendo regada.");
    }

    public void StopWateringEventListener()
    {
        //beingWatered = false;
        Debug.Log("A planta não está mais sendo regada.");
    }
}

