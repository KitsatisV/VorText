using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VorText.Stores;

namespace VorText.Http
{
    class FirebaseAuthHttpMessageHandler :DelegatingHandler
    {
        private readonly AuthenticationStore _authenticationStore;

        public FirebaseAuthHttpMessageHandler(AuthenticationStore authenticationStore)
        {
            _authenticationStore = authenticationStore;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Automatically refreshing token if expired
            FirebaseAuthLink firebaseAuthLink = await _authenticationStore.GetFreshAuthAsync();

            //Adding token to request
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", firebaseAuthLink.FirebaseToken);

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
