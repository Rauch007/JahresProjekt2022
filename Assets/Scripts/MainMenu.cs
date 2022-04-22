using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button Play;
    public Button Exit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() 
    {
        //Loads Scene 1 (MainGame) File --> Build Settings...
        Debug.Log("Start");
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        //Loads Scene 2 (Options) File --> Build Settings...
        SceneManager.LoadScene(2);
    }

    public void ExitGame() 
    {
        //Exits the Game, idk how it works
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                 Application.Quit();
        #endif
    }
}
