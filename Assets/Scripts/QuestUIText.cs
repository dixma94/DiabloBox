using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUIText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questText;
    [SerializeField] private TextMeshProUGUI stepText;

    public void SetQuestText(string text)
    {
        questText.text = text;
    }    
    public void SetStepText(string text)
    {
        stepText.text = text;
    }
}
