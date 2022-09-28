using AutoMapper;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using product_sv.Interfaces;
using product_sv.Models;

namespace product_sv.Services
{
    public class GrpcGroupService : ControllerBase, IGrpcGroupService
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<GrpcGroupService> logger;
        private readonly IMapper mapper;
        private readonly ProductContext context;

        public GrpcGroupService(IConfiguration configuration, ILogger<GrpcGroupService> logger, IMapper mapper, ProductContext context)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.mapper = mapper;
            this.context = context;
        }
        public ActionResult<IEnumerable<ProductGroup>>? GetGroups()
        {
            Console.WriteLine($"--> Calling gRPC Service on {configuration["GroupSv:Server"]}");

            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var channel = GrpcChannel.ForAddress(configuration["GroupSv:Server"]);
            var client = new GrpcGroup.GrpcGroupClient(channel);
            var request = new GetAllRequest();

            try {
                var reply = client.GetAllGroups(request);

                List<ProductGroup> groups = new List<ProductGroup>();
                mapper.Map<List<GrpcGroupModel>, List<ProductGroup>>(reply.Group.ToList(), groups);

                foreach(ProductGroup group in groups)
                {
                    IEnumerable<Product> products = context
                        .Products.Where(p => p.GroupId == group.GroupId);
                    group.Products.AddRange(products);
                }
                return Ok(groups);

            }catch(Exception e) {
                logger.LogError(e.Message, e);
                return null;
            }
        }
    }
}