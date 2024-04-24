using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class WateringCan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IWaterable waterableObject = other.GetComponent<IWaterable>();
        if (waterableObject != null)
        {
            waterableObject.StartWatering();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IWaterable waterableObject = other.GetComponent<IWaterable>();
        if (waterableObject != null)
        {
            waterableObject.StopWatering();
        }
    }
}
