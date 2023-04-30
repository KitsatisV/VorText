using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VorTextShared.Core.Responses;

namespace VorText.Queries
{
    public interface IGetSecretMessageQuery
    {
        [Get("/")]
        Task<SecretMessageResponse> Execute();
    }
}
