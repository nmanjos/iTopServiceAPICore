using iTopClientService.Contract.V1.Requests;
using iTopClientService.Contract.V1.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTopClientService.Service
{
    public interface IiTopService
    {
        Task<iTopCreateResponse> CreateInsidentAsync(iTopCreateRequest message);
    }
}
