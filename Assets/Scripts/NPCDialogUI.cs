using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        Hide();
        quitButton.onClick.AddListener(Hide);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(string text)
    {
        gameObject.SetActive(true);
        this.text.text = text;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
