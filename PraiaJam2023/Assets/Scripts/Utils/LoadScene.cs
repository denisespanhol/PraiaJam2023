using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Load(int i)
    {
        SceneManager.LoadScene(i);
        if (Time.timeScale == 0) Time.timeScale = 1;
    }

    public void Load(string i)
    {
        SceneManager.LoadScene(i);
        if (Time.timeScale == 0) Time.timeScale = 1;
    }
}
