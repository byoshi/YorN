using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using YorNService.DataObjects;
using YorNService.Models;

namespace YorNService.Controllers
{
    public class UserController : TableController<User>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            YorNContext context = new YorNContext();
            DomainManager = new EntityDomainManager<User>(context, Request, Services);
        }

        // GET tables/TodoItem
        public IQueryable<User> GetAllTodoItems()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<User> GetUserItem(string ID)
        {
            return Lookup(ID);
        }

        // PATCH tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<User> PatchUserItem(string username, Delta<User> patch)
        {
            return UpdateAsync(username, patch);
        }

        // POST tables/User
        public async Task<IHttpActionResult> PostUserItem(User item)
        {
            User current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { ID = current.ID }, current);
        }

        // DELETE tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUser(string ID)
        {
            return DeleteAsync(ID);
        }
    }
}