using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelselector : MonoBehaviour
{

    public void LOadingLevels(string nameOftheLevel)
    {
        SceneManager.LoadScene(nameOftheLevel);
    }
}