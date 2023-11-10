using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TipUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Image image;
    Color color;

    private void Start()
    {
        color = image.color;
    }
    public void ShowInfoAboutNPC(string text)
    {
        gameObject.SetActive(true);
        textMeshPro.text = text;

        image.color= new Color32(123, 123, 123, 255);
        image.fillAmount = 1;


    }
    public void ShowInfoAboutEnemy(string text,int enemyHealth,int maxHealth)
    {
        gameObject.SetActive(true);
        textMeshPro.text = text;
        image.color = new Color32(106, 21, 21, 255);

        image.fillAmount = (float)enemyHealth/maxHealth;

    }
    public void Hide()
    {
        gameObject.SetActive(false);

    }
}
