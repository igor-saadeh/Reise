using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCamera : MonoBehaviour
{
    private Camera mainCamera;
    //public Transform targetPosition; // O destino para onde voc� deseja mover a c�mera
    private float moveTime = 0.6f; // O tempo que levar� para a c�mera se mover para o destino
    Vector3 startPosition; // A posi��o inicial da c�mera

    private void Awake()
    {
        foreach (GameObject rootObject in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            Camera cameraComponent = rootObject.GetComponent<Camera>();
            if (cameraComponent != null)
            {
                mainCamera = cameraComponent;
                break;
            }
        }

        if (mainCamera != null)
        {
            Debug.Log("Refer�ncia da c�mera encontrada: " + mainCamera.name);
        }
        else
        {
            Debug.LogError("Nenhuma c�mera encontrada na cena.");
        }
    }

    private void Start()
    {
        startPosition = mainCamera.transform.position;  //0,0,0
    }

    public void MoveCameraToTarget()
    {
        Vector3 newPosition = new Vector3(startPosition.x + 1200f, startPosition.y, startPosition.z);

        StartCoroutine(MoveToPosition(newPosition, moveTime));
    }

    IEnumerator MoveToPosition(Vector3 targetPosition, float timeToMove)
    {
        float elapsedTime = 0;
        //Vector3 startingPos = transform.position;

        while (elapsedTime < timeToMove)
        {
            mainCamera.transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = targetPosition;
    }
}