using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coracao : MonoBehaviour
{
    public List<Sprite> coracoes;
    public Image field;
    public int startIndex = 0;

    public Button btn;

    public void nextHeart()
    {
        startIndex++;
        if (startIndex < coracoes.Count)
        {
            field.sprite = coracoes[startIndex];
        }
        else
        {
            //encerrar o minigame 1
            GameEvents.OnMinigame1Finished.Invoke();
        }

    }


}
