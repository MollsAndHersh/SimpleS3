using System.Threading;
using System.Threading.Tasks;

namespace Genbox.SimpleS3.Core.Abstracts
{
    public interface IRequestHandler
    {
        Task<TResp> SendRequestAsync<TReq, TResp>(TReq request, CancellationToken token = default) where TResp : IResponse, new() where TReq : IRequest;
    }
}