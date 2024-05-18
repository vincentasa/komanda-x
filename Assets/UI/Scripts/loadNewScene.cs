using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loadNewScene : MonoBehaviour
{
    public void OnMouseDown(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

