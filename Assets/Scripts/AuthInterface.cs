using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthInterface : MonoBehaviour
{
    public void SignIn()
    {
        Auth.Instance.SignInWithGoogle();
    }
}
