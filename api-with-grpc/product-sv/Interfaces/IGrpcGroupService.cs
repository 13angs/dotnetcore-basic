using Microsoft.AspNetCore.Mvc;
using product_sv.Models;

namespace product_sv.Interfaces
{
    public interface IGrpcGroupService
    {
        public ActionResult<IEnumerable<ProductGroup>>? GetGroups();
    }
}