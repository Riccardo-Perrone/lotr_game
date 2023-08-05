using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonControl : MonoBehaviour
{
    [SerializeField] private string gameScene = "Game";
    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }
}
