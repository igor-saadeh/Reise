using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class WateringCan : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

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

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = newPosition;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}