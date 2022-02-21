using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public void Toggle()
    {
        bool val = !gameObject.activeSelf;
        if (val)
        {
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
