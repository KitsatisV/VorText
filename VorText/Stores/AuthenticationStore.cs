using Firebase.Auth;
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

        public AuthenticationStore(FirebaseAuthProvider firebaseAuthProvider)
        {
            _firebaseAuthProvider = firebaseAuthProvider;
        }

        public User? CurrentUser => _currentFirebaseAuthlink?.User;

        public async Task Login(string email, string password)
        {
            //Performing the Log In
            _currentFirebaseAuthlink = await _firebaseAuthProvider.SignInWithEmailAndPasswordAsync(email, password);
        }

        internal Task<FirebaseAuthLink> GetFreshAuthAsync()
        {
            return _currentFirebaseAuthlink.GetFreshAuthAsync();
        }
    }
}
