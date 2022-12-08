using Microsoft.AspNetCore.Mvc;
using PMS.NET_7.Shared.Models;
using PMSDomain.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PMS.NET_7.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagementController : ControllerBase 
    {
        protected readonly PMSRepository _Repository;
        public ProjectManagementController(PMSRepository repository)
        {
            _Repository = repository;
        }

        [HttpGet("Getfromdatabase")]
        public async Task<IActionResult> GetList<T>() where T : class 
        {
            var entities = await _Repository.GetAllAsync<T>();
            return Ok(entities);
        }
    }
}
