using Ink;
using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class NPCDialogUI : MonoBehaviour
{
    public static event Action OnAcceptQuest;

    private const string ACCEPT_QUEST_TAG = "AcceptQuest";

    [SerializeField] private TextMeshProUGUI dialogueTextPrefab;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Button buttonPrefab = null;
    [SerializeField] private GameObject panelText = null;
    [SerializeField] private GameObject panelChoises = null;
    public Story story;
    public bool IsPlaying;
    // Start is called before the first frame update

    void Awake()
    {
        // Remove the default message
        RemoveChildren();
        Hide();
    }
    public void EnterDialogueMode(QuestStep questStep, TextAsset textAsset)
    {
        Show();
        story = new Story(textAsset.text);
        questStep?.FinishedQuestStep();
        RefreshView();
        IsPlaying = true;
    }
    public void EnterDialogueMode(TextAsset textAsset)
    {
        Show();
        story = new Story(textAsset.text);
        RefreshView();
        IsPlaying = true;
    }


    private void Show()
    {
        gameObject.SetActive(true);
        playerController.IsDialog = true;
    }
    private void Hide()
    {
        gameObject.SetActive(false);
        
    }

    private void ExitDialogueMode()
    {
        playerController.IsDialog = false;
        Hide();
        IsPlaying = false;
    }

    private IEnumerator SmoothText(string text, TextMeshProUGUI textMeshPro)
    {
        textMeshPro.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            yield return new WaitForSeconds(0.05f);
            textMeshPro.text += text[i];
        }
       
    }

    private void RefreshView()
    {
        // Remove all the UI on screen
        RemoveChildren();

        // Read all the content until we can't continue any more
        while (story.canContinue)
        {
            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            CreateContentView(text);


            
        }

        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
            }
        }
        // If we've read all the content and there's no choices, the story is finished!
        else
        {
            ExitDialogueMode();
        }
    }
    // Destroys all the children of this gameobject (all the UI)
    private void RemoveChildren()
    {
        int childCount = panelText.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            Destroy(panelText.transform.GetChild(i).gameObject);
        }
        childCount = panelChoises.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            Destroy(panelChoises.transform.GetChild(i).gameObject);
        }
    }
    // Creates a button showing the choice text
    Button CreateChoiceView(string text)
    {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(panelChoises.transform, false);

        // Gets the text from the button prefab
        TextMeshProUGUI choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
        choiceText.text = text;

        return choice;
    }
    private void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }
    // Creates a textbox showing the the line of text
    private void CreateContentView(string text)
    {
        TextMeshProUGUI storyText = Instantiate(dialogueTextPrefab) as TextMeshProUGUI;
        StartCoroutine(SmoothText(text, storyText));
        storyText.transform.SetParent(panelText.transform, false);
    }
}
