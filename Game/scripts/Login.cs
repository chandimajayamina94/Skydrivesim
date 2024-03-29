﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;


public class Login : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public Button StartSim;
    public Button loginButton;
    private bool LoginButtonclicked = false;


    private string Username;
    private string Password;
    private String[] Lines;
    private string DecryptedPass;
    private string sceneName = "scene001";

    public void LoginButton()
    {
        bool UN = false;
        bool PW = false;
        
        
        if (Username != "")
        {
            if (System.IO.File.Exists(@"E:/UnityTextFolder/" + Username + ".txt"))
            {
                Debug.Log(Username);
                UN = true;
                Lines = System.IO.File.ReadAllLines(@"E:/UnityTextFolder/" + Username + ".txt");
            }
            else
            {
                Debug.LogWarning("Username Invaild");
            }
        }
        else
        {
            Debug.LogWarning("Username Field Empty");
        }
        if (Password != "")
        {
            if (System.IO.File.Exists(@"E:/UnityTextFolder/" + Username + ".txt"))
            {
                Debug.Log(Password);
                int i = 1;
                foreach (char c in Lines[2])
                {
                    i++;
                    char Decrypted = (char)(c / i);
                    DecryptedPass += Decrypted.ToString();
                }
                if (Password == DecryptedPass)
                {
                    PW = true;
                }
                else
                {
                    Debug.LogWarning("Password Is invalid");
                }
            }
            else
            {
                Debug.LogWarning("Password Is invalid");
            }
        }
        else
        {
            Debug.LogWarning("Password Field Empty");
        }
        if (UN == true && PW == true)
        {
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            LoginButtonclicked = false;
            print("Login Sucessful");
            StartSim.interactable = true;
            // SceneManager.LoadScene(sceneName);
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        StartSim.interactable = false;
        Button btn = loginButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClickRegisterButton);
    }

    void TaskOnClickRegisterButton()
    {
        LoginButtonclicked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || LoginButtonclicked)
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Password != "" && Password != "")
            {
                LoginButton();
            }
        }
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }
}
