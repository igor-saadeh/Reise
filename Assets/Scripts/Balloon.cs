using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balloon : MonoBehaviour
{
    public List<Sprite> emojis = new List<Sprite>(); // Lista de emojis para exibir nos UI Images

    private void Awake()
    {
        // Coleta todas as UI Images filhas do Balloon
        foreach (Transform child in transform)
        {
            Image image = child.GetComponent<Image>();
            if (image != null && image.gameObject.name.StartsWith("Emoji"))
            {
                emojis.Add(null); // Adiciona um espa�o para cada imagem filha
            }
        }
    }

    public void AddEmoji(Sprite emoji)
    {
        // Encontra o pr�ximo Image filho dispon�vel e atribui o emoji
        for (int i = 0; i < emojis.Count; i++)
        {
            Image image = transform.Find($"Emoji{i + 1}").GetComponent<Image>();
            if (emojis[i] == null)
            {
                image.sprite = emoji;
                emojis[i] = emoji;
                Debug.Log($"Emoji {emoji.name} adicionado ao {image.name}");
                return; // Sai do m�todo ap�s atribuir o emoji ao primeiro Image dispon�vel
            }
        }

        Debug.LogWarning("N�mero m�ximo de emojis alcan�ado para este Balloon.");
    }
}




//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Balloon : MonoBehaviour
//{
//    public List<Sprite> emojis = new List<Sprite>(); // Lista de emojis para exibir nos UI Images
//    public List<Image> emojiImages = new List<Image>(); // Lista de UI Images onde ser�o exibidos os emojis

//    private void Awake()
//    {
//        // Coleta todas as UI Images filhas do Balloon
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
//        // Verifica se h� uma UI Image dispon�vel para exibir o emoji
//        foreach (Image image in emojiImages)
//        {
//            if (image.sprite == null)
//            {
//                image.sprite = emoji;
//                emojis.Add(emoji);
//                Debug.Log($"Emoji {emoji.name} adicionado ao {image.name}");
//                return; // Sai do m�todo ap�s atribuir o emoji ao primeiro UI Image dispon�vel
//            }
//        }

//        Debug.LogWarning("N�mero m�ximo de emojis alcan�ado para este Balloon.");
//    }
//}

//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Balloon : MonoBehaviour
//{
//    public List<Image> emojiImages = new List<Image>(); // Lista de UI Images onde ser�o exibidos os emojis

//    private void Awake()
//    {
//        // Coleta todas as UI Images filhas do Balloon
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
//        // Encontra a pr�xima UI Image dispon�vel para exibir o emoji
//        foreach (Image image in emojiImages)
//        {
//            if (image.sprite == null)
//            {
//                image.sprite = emoji;
//                Debug.Log($"Emoji {emoji.name} adicionado ao {image.name}");
//                return; // Sai do m�todo ap�s atribuir o emoji ao primeiro UI Image dispon�vel
//            }
//        }

//        Debug.LogWarning("N�mero m�ximo de emojis alcan�ado para este Balloon.");
//    }
//}
