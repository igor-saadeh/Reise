using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmojiManager : MonoBehaviour
{
    private List<Sprite> emojis; // Lista com os sprites de emojis
    private Button[] emojiButtons;  // Array de Botões onde os emojis serão exibidos (UI)
    private Balloon[] balloons; // Array de Balloons para exibir os emojis selecionados

    private List<Sprite> selectedEmojis = new List<Sprite>(); // Lista de emojis selecionados pelo jogador
    private int currentStage = 0; // Etapa atual
    private int emojisPerStage = 3; // Número de emojis por etapa
    //private int totalEmojis = 9; // Total de emojis no minigame
    private int emojisSelectedInCurrentStage = 0; // Quantidade de emojis selecionados na etapa atual
    private int startIndex = 0; // Índice inicial dos emojis da etapa

    private void Awake()
    {
        LoadEmojis();
        FindEmojiButtons();
        FindBalloons();
        SetupEmojiButtons();
        ShowEmojis();
    }

    private void FindEmojiButtons()
    {
        // Encontra todos os botões na cena ou no objeto que contém o script
        emojiButtons = GetComponentsInChildren<Button>();
    }

    private void FindBalloons()
    {
        // Encontra todos os Balloons na cena ou no objeto que contém o script
        balloons = GetComponentsInChildren<Balloon>();
    }

    private void SetupEmojiButtons()
    {
        foreach (Button button in emojiButtons)
        {
            button.onClick.AddListener(() => OnEmojiButtonClicked(button));
        }
    }

    private void LoadEmojis()
    {
        emojis = new List<Sprite>(Resources.LoadAll<Sprite>("Minigame4"));
        Debug.Log("Emojis carregados: " + emojis.Count);
    }

    private void ShowEmojis()
    {
        ClearEmojiButtons();

        for (int i = 0; i < emojiButtons.Length; i++)
        {
            if (startIndex + i < emojis.Count)
            {
                emojiButtons[i].image.sprite = emojis[startIndex + i];
                emojiButtons[i].interactable = true;
            }
        }
    }

    private void OnEmojiButtonClicked(Button button)
    {
        int buttonIndex = System.Array.IndexOf(emojiButtons, button);
        int emojiIndex = startIndex + buttonIndex;

        if (emojiIndex < emojis.Count && emojisSelectedInCurrentStage < emojisPerStage)
        {
            Sprite emoji = emojis[emojiIndex];
            selectedEmojis.Add(emoji);
            emojisSelectedInCurrentStage++;

            Debug.Log("Emoji selecionado: " + emoji.name);
            Debug.Log("Total de emojis selecionados: " + selectedEmojis.Count);

            if (emojisSelectedInCurrentStage == emojisPerStage)
            {
                balloons[currentStage].AddEmoji(selectedEmojis.ToArray()); // Adiciona os emojis ao Balloon correspondente
                GameEvents.OnMiniGameStepCompleted.Invoke();
                NextStage();
            }
        }
        else
        {
            Debug.LogError("Índice de emoji fora dos limites ou etapa completa: " + emojiIndex);
        }
    }

    private void NextStage()
    {
        currentStage++;
        startIndex = currentStage * emojisPerStage;
        emojisSelectedInCurrentStage = 0;
        selectedEmojis.Clear();

        if (currentStage < balloons.Length)
        {
            ShowEmojis();
        }
        else
        {
            EndMiniGame();
        }

        Debug.Log("Etapa atual: " + currentStage);
    }

    private void EndMiniGame()
    {
        foreach (Button button in emojiButtons)
        {
            button.interactable = false;
        }

        Debug.Log("Minigame finalizado.");
        // Adicione aqui qualquer lógica adicional para o fim do minigame
    }

    private void ClearEmojiButtons()
    {
        foreach (Button button in emojiButtons)
        {
            button.image.sprite = null;
            button.onClick.RemoveAllListeners(); // Limpa os listeners anteriores
        }

        SetupEmojiButtons(); // Reconfigura os listeners
    }
}