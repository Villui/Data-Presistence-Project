using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public void InsertedPlayerName(TMP_InputField inputField)
    {
        // add code here to handle when a color is selected
        NameManager.Instance.playerName = inputField.GetComponent<TMP_InputField>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        InsertedPlayerName(inputField);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
