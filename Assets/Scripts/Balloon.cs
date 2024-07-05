using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{
    private List<Image> emojiImages = new List<Image>(); // Lista de UI Images onde serão exibidos os emojis
    private int currentIndex = 0; // Índice atual para atribuição dos emojis

    private void Awake()
    {
        // Coleta todas as UI Images filhas do Balloon
        foreach (Transform child in transform)
        {
            Image image = child.GetComponent<Image>();
            if (image != null)
            {
                emojiImages.Add(image);
            }
        }
    }


    public void AddEmoji(Sprite[] emojis)
    {
        foreach (Sprite emoji in emojis)
        {
            if (currentIndex < emojiImages.Count)
            {
                emojiImages[currentIndex].sprite = emoji;
                currentIndex++;
                Debug.Log($"Emoji {emoji.name} adicionado ao Balloon.");
            }
            else
            {
                Debug.LogWarning("Número máximo de emojis alcançado para este Balloon.");
                return; // Sai do método se o número máximo de emojis já foi alcançado
            }
        }
        gameObject.GetComponent<Image>().enabled = true;
        emojiImages[0].enabled = true;
        emojiImages[1].enabled = true;
        emojiImages[2].enabled = true;

        // fades the image out when you click
        StartCoroutine(FadeImage(true));
    }


    IEnumerator FadeImage(bool fadeAway)
    {
        //// fade from opaque to transparent
        //if (fadeAway)
        //{
        //    // loop over 1 second backwards
        //    for (float i = 1; i >= 0; i -= Time.deltaTime)
        //    {
        //        // set color with i as alpha
        //        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, i);
        //        emojiImages[0].color = new Color(1, 1, 1, i);
        //        emojiImages[0].color = new Color(1, 1, 1, i);
        //        emojiImages[0].color = new Color(1, 1, 1, i);
        //        yield return null;
        //    }
        //}
        // fade from transparent to opaque
        if (fadeAway)
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                Image img = gameObject.GetComponent<Image>();
                img.color = new Color(img.color.r, img.color.g, img.color.b, i);              
                //gameObject.GetComponent<Image>().color = new Color(1, 1, 1, i);
                emojiImages[0].color = new Color(1, 1, 1, i);
                emojiImages[1].color = new Color(1, 1, 1, i);
                emojiImages[2].color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}