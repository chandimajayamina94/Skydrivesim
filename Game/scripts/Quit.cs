using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void quitApplication()
    {
        Debug.Log(" has quit the show ");
        Application.Quit();
    }
}
