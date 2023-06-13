using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI highScoreText;

    public void NewPlayerName(string name)
    {
        SaveName.Instance.playerName = name;
    }

    private void Start()
    {
        if (SaveName.Instance != null)
        {
            highScoreText.text = "Best Score: " + SaveName.Instance.playerName + " - " + SaveName.Instance.bestScore;
        }
        else
        {
            highScoreText.text = "Best Score: 0";
        }
            
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }


}
