using AutoMapper;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AddressController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateAddressDto enderecoDto)
        {
            Address address = _mapper.Map<Address>(enderecoDto);
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = address.Id }, address);
        }

        [HttpGet]
        public IEnumerable<Address> RecuperaEnderecos()
        {
            return _context.Addresses;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(endereco => endereco.Id == id);
            if (address != null)
            {
                ReadAddressDto enderecoDto = _mapper.Map<ReadAddressDto>(address);

                return Ok(enderecoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateAddressDto enderecoDto)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            _mapper.Map(enderecoDto, address);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            _context.Remove(address);
            _context.SaveChanges();
            return NoContent();
        }

    }
}