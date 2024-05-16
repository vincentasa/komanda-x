using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class loadNewScene : MonoBehaviour
{
    public string sceneName;

    public void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName);
    }
}

