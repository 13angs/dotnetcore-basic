using AutoMapper;
using group_sv.Models;
using Grpc.Core;

namespace group_sv.Services
{
    public class GrpcGroupService : GrpcGroup.GrpcGroupBase
    {
        private readonly GroupContext context;
        private readonly IMapper mapper;

        public GrpcGroupService(GroupContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public override Task<GroupResponse> GetAllGroups(GetAllRequest request, ServerCallContext serverContext)
        {
            GroupResponse res = new GroupResponse();
            IList<GrpcGroupModel> groups = context.Groups
                                            .Select(g => mapper.Map<GrpcGroupModel>(g))
                                            .ToList();
            res.Group.AddRange(groups);
            return Task.FromResult(res);
        }
    }
}