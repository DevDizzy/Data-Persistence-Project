using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField scorerName;
    public Text menuScoreText;

    public void Start()
    {
        menuScoreText.text = SessionManager.Instance.highScoreText;
    }

    public void StartNew()
    {
        SessionManager.Instance.highScorerName = scorerName.text;
        Debug.Log("Set scorer name:" + SessionManager.Instance.highScorerName);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
