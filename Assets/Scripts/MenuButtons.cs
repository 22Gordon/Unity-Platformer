using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
