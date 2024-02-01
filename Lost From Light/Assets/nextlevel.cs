using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextlevel : MonoBehaviour
{
    public void nextLevel()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
