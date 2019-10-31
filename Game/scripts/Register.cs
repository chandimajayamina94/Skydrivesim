using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{

    public GameObject username;
    public GameObject email;
    public GameObject password;
    public GameObject confirmpassword;
    public Button registerButton;
    private bool RegisterButtonclicked = false;

    private string Username;
    private string Email;
    private string Password;
    private string Confirmpassword;

    private string form;
    private bool EmailValid = false;
    private string[] Characters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "L", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
        "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "_", "-"
    };

    public void RegisterButton()
    {
        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;

       
        //Check User name
        if (Username != "")
        {
            if (!System.IO.File.Exists(@"E:/UnityTextFolder/" + Username + ".txt"))
            {
                //Debug.Log("Register button function username");
                UN = true;
            }
            else
            {
                Debug.LogWarning(" User name taken ");
            }
        }
        else
        {
            Debug.LogWarning(" User name is empty ");
        }

        //Check email
        if (Email != "")
        {
            EmailValidation ();
            if (EmailValid)
            {
                if (Email.Contains("@"))
                {
                    if (Email.Contains("."))
                    {
                        //Debug.Log("Register button function email");
                        EM = true;
                        /* if (Email.Contains("com"))
                        {
                            
                        }
                        else
                        {
                            Debug.LogWarning(" Email is not correct ");
                        }*/
                    }
                    else
                    {
                        Debug.LogWarning(" Email is not correct ");
                    }
                }
                else
                {
                    Debug.LogWarning(" Email is not correct ");
                }
            }
            else
            {
                Debug.LogWarning(" Email is not correct ");
            }
        }
        else
        {
            Debug.LogWarning(" Email is empty ");
        }

        //Check the Password 
        if (Password != "")
        {
            if (Password.Length >5)
            {
                //Debug.Log("Register button function password");
                PW = true;
            }
            else
            {
                Debug.LogWarning(" Password is too short ");
            }
        }
        else
        {
            Debug.LogWarning(" Password is empty ");
        }

        if (Confirmpassword != "")
        {
            if (Confirmpassword == Password)
            {
               // Debug.Log("Register button function confpass");
                CPW = true;
            }
            else
            {
                Debug.LogWarning(" Password mismatch ");
            }
        }
        else
        {
            Debug.LogWarning(" Confirmation Password is empty ");
        }


        if (UN == true && EM == true && PW == true && CPW == true)
        {
            //Debug.Log("Register button function  all true");
            bool Clear = true;
            int i = 1;
            foreach (char c in Password)
            {
                if (Clear)
                {
                    Password = "";
                    Clear = false;
                }
                i++;
                char Encrypted = (char)(c * i);
                Password += Encrypted.ToString();
            }

            form = (Username + "\n" + Email + "\n" + Password);
            System.IO.File.WriteAllText(@"E:/UnityTextFolder/" + Username + ".txt", form);
            username.GetComponent<InputField>().text = "";
            email.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            confirmpassword.GetComponent<InputField>().text = "";
            RegisterButtonclicked = false;
            print("Registration complete");
        }



    }

    void EmailValidation()
    {
        bool SW = false;
        bool EW = false;


        for (int i = 0; i < Characters.Length; i++)
        {
            if (Email.StartsWith(Characters[i]))
            {
                SW = true;
            }
        }
        for(int i = 0; i < Characters.Length; i++)
        {
            if (Email.EndsWith(Characters[i]))
            {
                EW = true;
            }
        }

        if (SW == true && EW == true)
        {
            EmailValid = true;
        }
        else
        {
            EmailValid = false;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        Button btn = registerButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClickRegisterButton);
    }

    void TaskOnClickRegisterButton()
    {
        RegisterButtonclicked = true;
    }


    // Update is called once per frame
    void Update()
    {
        

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (username.GetComponent<InputField>().isFocused)
                {
                    email.GetComponent<InputField>().Select();
                }
                if (email.GetComponent<InputField>().isFocused)
                {
                    password.GetComponent<InputField>().Select();
                }
                if (password.GetComponent<InputField>().isFocused)
                {
                    confirmpassword.GetComponent<InputField>().Select();
                }

            }


        if (Input.GetKeyDown(KeyCode.Return) || RegisterButtonclicked)
        {
            if (Username != "" && Email != "" && Password != "" && Confirmpassword != "")
            {
                RegisterButton();
            }
            else
            {
                RegisterButtonclicked = false;
            }
        }

        Username = username.GetComponent<InputField>().text;
        Email = email.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        Confirmpassword = confirmpassword.GetComponent<InputField>().text;

    }
}
