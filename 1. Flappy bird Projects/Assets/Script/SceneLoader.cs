using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadScene(string name)
    {
        //melakukan pengecekan jika nama tidak null atau empty
        if(!string.IsNullOrEmpty(name))
        {
            SceneManager.LoadScene(name);
        }
    }
}
