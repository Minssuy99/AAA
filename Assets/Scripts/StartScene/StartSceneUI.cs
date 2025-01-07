using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{
    public void OnClickNewGameButton()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("OnClickNewGameButton");
    }

    public void OnClickOptionButton()
    {
        Debug.Log("OnClickOptionButton");
    }

    public void OnClickExitButton()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("OnClickExitButton");
        #else
        Application.Quit();
        #endif
    }
}
