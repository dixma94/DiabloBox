using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIStartMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(LoadMainScene);
    }

    private void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
