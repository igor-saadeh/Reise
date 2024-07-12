using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPuzzle : MonoBehaviour
{
    public int amount = 0;

    public GameObject thecoolone;
    public List<GameObject> list = new List<GameObject>();

    private void Start()
    {
        thecoolone.SetActive(false);
    }

    private void Update()
    {
        if(!thecoolone.activeSelf && amount == list.Count)
        {
            thecoolone.SetActive(true);
            for (int i = 0; i < list.Count; i++)
            {
                list[i].SetActive(false);
            }
            GameEvents.OnMinigame4Finished.Invoke();
        }
    }
}
