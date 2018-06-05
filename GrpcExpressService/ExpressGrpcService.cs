using Grpc.Core;
using GrpcBase;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Grpc.Express.ExpressService;
using  static Grpc.Express.ExpressService.ExpessAnalyzeService;
namespace GrpcExpress.Grpc
{   
    public class ExpressGrpcService  : IGrpcServerService,  ExpessAnalyzeServiceBase
    {
        protected readonly ILogger<ExpressGrpcService> _logger;
        
        public ExpressGrpcService(ILogger<ExpressGrpcService> logger)
        {
            _logger = logger;
        }
        public override  Task<GetBusinessActivityResponse> GetBusinessActivityByYearPair(GetBusinessActivityRequest req )
        {

        }
    }
}