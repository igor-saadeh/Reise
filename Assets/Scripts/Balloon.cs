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
    }
}


//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Balloon : MonoBehaviour
//{
//    private List<Image> emojiImages = new List<Image>(); // Lista de UI Images onde serão exibidos os emojis
//    private int currentIndex = 0; // Índice atual para atribuição dos emojis

//    //public Image[] eImages;

//    private void Awake()
//    {
//         //Coleta todas as UI Images filhas do Balloon
//        foreach (Transform child in transform)
//        {
//            Image image = child.GetComponent<Image>();
//            if (image != null)
//            {
//                emojiImages.Add(image);
//            }
//        }
//    }

//    public void AddEmoji(Sprite emoji)
//    {
//        if (currentIndex < emojiImages.Count)
//        {
//            emojiImages[currentIndex].sprite = emoji;
//            currentIndex++;
//            Debug.Log($"Emoji {emoji.name} adicionado ao Balloon.");
//        }
//        else
//        {
//            Debug.LogWarning("Número máximo de emojis alcançado para este Balloon.");
//        }
//    }
//}