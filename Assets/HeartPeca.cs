using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPeca : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    public bool locked = false;

    RectTransform trans;

    private void Start()
    {
        trans = GetComponent<RectTransform>();
    }
    void Update()
    {
        if (!locked && isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = newPosition;
        }
    }
    void OnMouseDown()
    {
        if (!locked)
        {
            isDragging = true;
            offset = transform.position - GetMouseWorldPosition();
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        Debug.Log((Vector2.zero - trans.anchoredPosition).magnitude);
        if(!locked && (Vector2.zero - trans.anchoredPosition).magnitude < 40f)
        {
            locked = true;
            trans.anchoredPosition = Vector2.zero;
            GetComponentInParent<HeartPuzzle>().amount++;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
