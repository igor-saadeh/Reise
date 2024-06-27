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
                emojis.Add(null); // Adiciona um espaço para cada imagem filha
            }
        }
    }

    public void AddEmoji(Sprite emoji)
    {
        // Encontra o próximo Image filho disponível e atribui o emoji
        for (int i = 0; i < emojis.Count; i++)
        {
            Image image = transform.Find($"Emoji{i + 1}").GetComponent<Image>();
            if (emojis[i] == null)
            {
                image.sprite = emoji;
                emojis[i] = emoji;
                Debug.Log($"Emoji {emoji.name} adicionado ao {image.name}");
                return; // Sai do método após atribuir o emoji ao primeiro Image disponível
            }
        }

        Debug.LogWarning("Número máximo de emojis alcançado para este Balloon.");
    }
}




//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Balloon : MonoBehaviour
//{
//    public List<Sprite> emojis = new List<Sprite>(); // Lista de emojis para exibir nos UI Images
//    public List<Image> emojiImages = new List<Image>(); // Lista de UI Images onde serão exibidos os emojis

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
//        // Verifica se há uma UI Image disponível para exibir o emoji
//        foreach (Image image in emojiImages)
//        {
//            if (image.sprite == null)
//            {
//                image.sprite = emoji;
//                emojis.Add(emoji);
//                Debug.Log($"Emoji {emoji.name} adicionado ao {image.name}");
//                return; // Sai do método após atribuir o emoji ao primeiro UI Image disponível
//            }
//        }

//        Debug.LogWarning("Número máximo de emojis alcançado para este Balloon.");
//    }
//}

//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Balloon : MonoBehaviour
//{
//    public List<Image> emojiImages = new List<Image>(); // Lista de UI Images onde serão exibidos os emojis

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
//        // Encontra a próxima UI Image disponível para exibir o emoji
//        foreach (Image image in emojiImages)
//        {
//            if (image.sprite == null)
//            {
//                image.sprite = emoji;
//                Debug.Log($"Emoji {emoji.name} adicionado ao {image.name}");
//                return; // Sai do método após atribuir o emoji ao primeiro UI Image disponível
//            }
//        }

//        Debug.LogWarning("Número máximo de emojis alcançado para este Balloon.");
//    }
//}
