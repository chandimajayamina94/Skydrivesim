using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadingScenes : MonoBehaviour
{
    public void SceneLoader(int scene)
    {
        Debug.Log(scene + " Scene loaded");
        SceneManager.LoadScene(scene);
    } 

}
