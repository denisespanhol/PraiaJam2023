using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject Image;
    public void Pause()
    {
        if (Time.timeScale == 0) Time.timeScale = 1;

        else if (Time.timeScale == 1) Time.timeScale = 0;
    }

    public void Control()
    {
        if(Image.activeInHierarchy)
        {
            Image.SetActive(false);
        }
        else
        {
            Image.SetActive(true);
        }
    }
}
