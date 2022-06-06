using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Data;
using MoviesAPI.Data.Dtos.Manager;
using MoviesAPI.Models;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ManagerController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddManager([FromBody] CreateManagerDto managerDto)
        {
            Manager manager = _mapper.Map<Manager>(managerDto);
            _context.Managers.Add(manager);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetManagerById), new { Id = manager.Id }, manager);   
        }

        [HttpGet]
        public IActionResult GetManagerById(int id)
        {
            Manager manager = _context.Managers.FirstOrDefault(manager => manager.Id == id);
            if (manager != null)
            {
                ReadManagerDto managerDto = _mapper.Map<ReadManagerDto>(manager);
                return Ok(managerDto);
            }
            return NotFound();
        }
    }
}
