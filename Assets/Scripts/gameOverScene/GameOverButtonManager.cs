using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtonManager : MonoBehaviour
{

    public void PressRetry()
    {
        SceneManager.LoadScene("level1");
    }
    public void Quit()
    {
        
    }

}
