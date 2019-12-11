using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Auth : Singleton<Auth>
{
    public FirebaseUser user;
    private FirebaseAuth auth;
    
    private void Awake() {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    private void InitAuth()
    {
        if (auth == null)
        {
            auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
            auth.StateChanged += AuthStateChanged;
            AuthStateChanged(this, null);
        }
    }
    
    private void AuthStateChanged(object sender, System.EventArgs eventArgs) {
        if (auth.CurrentUser == user) return;
        
        var signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
        if (!signedIn && user != null) {
            Debug.Log("Signed out " + user.UserId);
        }
        user = auth.CurrentUser;
        if (signedIn) {
            Debug.Log("Signed in " + user.UserId);
            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile {
                DisplayName = "Kyle Gray",
            };
            user.UpdateUserProfileAsync(profile).ContinueWith(a => { });
            SceneManager.LoadScene("POIPlacement");
        }
    }
    
    public void SignInWithGoogle()
    {
        var editorSignInCompleted = new TaskCompletionSource<FirebaseUser> ();
        auth.SignInWithCredentialAsync(EmailAuthProvider.GetCredential("test@example.com", "password")).ContinueWith(authTask => {
            if (authTask.IsCanceled) {
                editorSignInCompleted.SetCanceled();
            } else if (authTask.IsFaulted) {
                editorSignInCompleted.SetException(authTask.Exception);
            } else {
                editorSignInCompleted.SetResult(authTask.Result);
            }
        });
        if (auth.CurrentUser == null || auth.CurrentUser.Email != "debug code")
        {
            return;
        }
        
        /*GoogleSignIn.Configuration = new GoogleSignInConfiguration {
            RequestIdToken = true,
            WebClientId = "796549363210-pn3ob20k5772fma8moj25kt3ur9dtpn1.apps.googleusercontent.com"
        };

        var signIn = GoogleSignIn.DefaultInstance.SignIn ();

        var signInCompleted = new TaskCompletionSource<FirebaseUser> ();
        signIn.ContinueWith (task => {
            if (task.IsCanceled) {
                signInCompleted.SetCanceled ();
            } else if (task.IsFaulted) {
                signInCompleted.SetException (task.Exception);
            } else {
                var credential = GoogleAuthProvider.GetCredential (task.Result.IdToken, null);
                auth.SignInWithCredentialAsync(credential).ContinueWith(authTask => {
                    if (authTask.IsCanceled) {
                        signInCompleted.SetCanceled();
                    } else if (authTask.IsFaulted) {
                        signInCompleted.SetException(authTask.Exception);
                    } else {
                        signInCompleted.SetResult(authTask.Result);
                    }
                });
            }
        });*/
    }
}
