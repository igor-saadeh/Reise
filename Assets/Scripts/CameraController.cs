using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCamera : MonoBehaviour
{
    private Camera mainCamera;
    private float moveTime = 0.6f; // O tempo que levar� para a c�mera se mover para o destino
    private Vector3 startPosition; // A posi��o inicial da c�mera
    private bool isMoving = false; // Verifica se a c�mera est� em movimento

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
        startPosition = mainCamera.transform.position;
    }

    public void MoveCameraToTarget()
    {
        if (!isMoving)
        {
            Vector3 newPosition = mainCamera.transform.position + new Vector3(1200f, 0, 0);
            StartCoroutine(MoveToPosition(newPosition, moveTime));
        }
    }

    IEnumerator MoveToPosition(Vector3 targetPosition, float timeToMove)
    {
        isMoving = true;
        float elapsedTime = 0;
        Vector3 startingPos = mainCamera.transform.position;

        while (elapsedTime < timeToMove)
        {
            mainCamera.transform.position = Vector3.Lerp(startingPos, targetPosition, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = targetPosition;
        startPosition = targetPosition; // Atualiza a posi��o inicial para a nova posi��o
        isMoving = false;
    }
}
