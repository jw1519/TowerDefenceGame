using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonManager : MonoBehaviour
{
    public TextMeshProUGUI GoldText;

    private void Start()
    {
        GoldText.SetText("Total Gold Accumulated " + Gold.TotalGoldEarned);
    }
    public void PressRetry()
    {
        SceneManager.LoadScene("Level");
    }
    public void Quit()
    {
       Application.Quit();
       UnityEditor.EditorApplication.isPlaying = false;
    }


}
