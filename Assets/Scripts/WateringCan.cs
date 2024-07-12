using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class WateringCan : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IWaterable waterableObject = collision.collider.GetComponent<IWaterable>();
        if (waterableObject != null)
        {
            //waterableObject.StartWatering();
            Debug.Log("Colidindo");
            GameEvents.OnWateringStart.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IWaterable waterableObject = collision.collider.GetComponent<IWaterable>();
        if (waterableObject != null)
        {
            //waterableObject.StopWatering();
            Debug.Log("Saiu da Colisao");
            GameEvents.OnWateringStop.Invoke();
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
        transform.Rotate(0, 0, 45);
    }

    void OnMouseUp()
    {
        isDragging = false;
        transform.position = startPosition;
        transform.Rotate(0, 0, -45);
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