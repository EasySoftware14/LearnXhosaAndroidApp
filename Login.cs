using System;
using Android.App;
using Android.Content.Res;
using Android.OS;
using Android.Widget;

namespace LearnXhosaApp
{
    [Activity(Label = "Login", Theme = "@style/android:Theme.Holo.Light.NoActionBar", MainLauncher = true)]
    public class Login : Activity
    {
        private EditText username;
        private EditText password;
        private Button mButtonSignUp;
        private Button mButtonSignIn;
        private ProgressBar mProgressBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.Login);

            mButtonSignIn = FindViewById<Button>(Resource.Id.btnSignIn);
            mButtonSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            username = FindViewById<EditText>(Resource.Id.txtEmail);
            password = FindViewById<EditText>(Resource.Id.txtPassword);
            mProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            //Login button click action
            mButtonSignIn.Click += LoginEvent; //delegate { StartActivity(typeof(MainActivity)); };
            mButtonSignUp.Click += MButtonSignUp_Click;
        }

        private void MButtonSignUp_Click(object sender, EventArgs e)
        {
            var transaction = FragmentManager.BeginTransaction();
            var signUpDialog = new DialogSignUp();
            signUpDialog.Show(transaction, "Sign Up");

            signUpDialog.mOnSignUpEvent += SignUpDialog_mOnSignUpEvent;


        }

        private void SignUpDialog_mOnSignUpEvent(object sender, OnSignUpEventArgs e)
        {
            var t = e.FirstName;
        }

        public void LoginEvent(object sender, EventArgs args)
        {
            Toast.MakeText(this, "Login Button Clicked!", ToastLength.Short).Show();
        }
    }
}