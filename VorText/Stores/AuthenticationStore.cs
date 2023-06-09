﻿using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VorText.ViewModels;

namespace VorText.Stores
{
    class AuthenticationStore
    {
        private readonly FirebaseAuthProvider _firebaseAuthProvider;

        private FirebaseAuthLink _currentFirebaseAuthlink;

        //Constructor
        public AuthenticationStore(FirebaseAuthProvider firebaseAuthProvider)
        {
            _firebaseAuthProvider = firebaseAuthProvider;
        }

        //Getting the current user
        public User? CurrentUser => _currentFirebaseAuthlink?.User;

        //Methods
        public async Task Login(string email, string password)
        {
            //Performing the Log In
            _currentFirebaseAuthlink = await _firebaseAuthProvider.SignInWithEmailAndPasswordAsync(email, password);
        }

        public void Logout()
        {
            _currentFirebaseAuthlink = null;
        }

        internal async Task<FirebaseAuthLink> GetFreshAuthAsync()
        {
            if (_currentFirebaseAuthlink == null)
            {
                return null;
            }

            //Refreshing token in case it's expired
            return await _currentFirebaseAuthlink.GetFreshAuthAsync();
        }
    }
}
