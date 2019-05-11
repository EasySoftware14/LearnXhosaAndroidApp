using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LearnXhosaApp
{
    public class OnSignUpEventArgs : EventArgs
    {
        private string mEmail;
        private string mPassword;
        private string mFirstName;
        public string Email
        {
            get { return mEmail;}
            set { mEmail = value; }
        }
        public string Password
        {
            get { return mPassword; }
            set { mPassword = value; }
        }
        public string FirstName
        {
            get { return mFirstName; }
            set { mFirstName = value; }
        }
        public OnSignUpEventArgs(string firstName, string password, string email) : base()
        {
            FirstName = firstName;
            Password = password;
            Email = email;
        }
    }
    public class DialogSignUp : DialogFragment
    {
        private EditText mEmail;
        private EditText mPassWord;
        private EditText mFirstName;
        private Button mBtnSignUp;

        public event EventHandler<OnSignUpEventArgs> mOnSignUpEvent;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);
            mEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mPassWord = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mFirstName = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            mBtnSignUp = view.FindViewById<Button>(Resource.Id.btnSignUp);

            mBtnSignUp.Click += MBtnSignUp_Click;

            return view;
        }

        private void MBtnSignUp_Click(object sender, EventArgs e)
        {
            mOnSignUpEvent.Invoke(this, new OnSignUpEventArgs(mFirstName.Text, mPassWord.Text, mEmail.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);

            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}