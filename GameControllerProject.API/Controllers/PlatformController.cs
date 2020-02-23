using GameControllerProject.Api.Controllers.Base;
using GameControllerProject.Domain.Arguments.Platform;
using GameControllerProject.Domain.Interfaces.Services;
using GameControllerProject.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace GameControllerProject.API.Controllers
{
    [RoutePrefix("api/Platforms")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _platformService;

        public PlatformController(IPlatformService platformService, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _platformService = platformService;
        }

        [HttpPost]
        [Route("AddPlatform")]
        public async Task<HttpResponseMessage> AddPlatform(AddPlatformRequest request)
        {
            try
            {
                var response = _platformService.AddPlatForm(request);
                return await ResponseAsync(response, _platformService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpGet]
        [Route("GetAllPlatforms")]
        public async Task<HttpResponseMessage> GetAllPlatforms()
        {
            try
            {
                var response = _platformService.GetAllPlatforms();
                return await ResponseAsync(response, _platformService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("ModifyPlatform")]
        public async Task<HttpResponseMessage> ModifyPlatform(ModifyPlatformRequest request)
        {
            try
            {
                var response = _platformService.ModifyPlatform(request);
                return await ResponseAsync(response, _platformService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [HttpPost]
        [Route("DeletePlatform")]
        public async Task<HttpResponseMessage> DeletePlatform(DeletePlatformRequest request)
        {
            try
            {
                var response = _platformService.DeletePlatform(request.Id);
                return await ResponseAsync(response, _platformService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}