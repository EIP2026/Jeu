using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void LoadGameScene()
    {
        Debug.Log("Loading Game Scene");
        SceneManager.LoadSceneAsync("Game");
    }
}
