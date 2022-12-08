using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS.NET_7.Shared.Models;
using PMSDomain.Data;
using PMSDomain.Repositories;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PMS.NET_7.Server.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class PMSController : ControllerBase
    {
        protected readonly PMSRepository _Repository;
        public PMSController(PMSRepository repository)
        {
            _Repository = repository;
        }

        [HttpGet("GetProjectTypeTable")]
        public async Task<IActionResult> GetList() 
        {
            var entities = await  _Repository.GetAllAsync<ProjectTypesTable>();
            return Ok(entities);
        }
        [HttpGet("GetGameTypes")]
        public async Task<IActionResult> GetGameList()
        {
            var entities = await _Repository.GetAllAsync<GameTypesTable>();
            return Ok(entities);
        }
        [HttpGet("GetAppTypes")]
        public async Task<IActionResult> GetAppList()
        {
            var entities = await _Repository.GetAllAsync<ApplicationTypesTable>();
            return Ok(entities);
        }
        //[HttpGet("{id}")]
        //public virtual async Task<IActionResult> GetById(int id)
        //{
        //    var entity = await _Repository.GetByIdAsync<T>(id);
        //    if(entity == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(entity);
        //}
        [HttpPost("SaveProjectType")]
        public  virtual async Task<IActionResult> AddToDatabase(ProjectTypesTable entityclass)
        {
            await  _Repository.SaveAsync(entityclass);
            return Ok();
        }
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update<T>(T entiity) where T : class
        {
            if(entiity == null)
            {
                return BadRequest();
            }
            _Repository.UpdateAsync(entiity);
            

            return NoContent();
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var entity = await  _Repository.DeleteAsync();
        //    if(entity == null)
        //    {
        //        return NotFound();
        //    }
        //     _Repository.Set<T>().Remove(entity);
        //    await  _Repository.SaveChangesAsync();
        //    return NoContent();
        //}
    }
}
