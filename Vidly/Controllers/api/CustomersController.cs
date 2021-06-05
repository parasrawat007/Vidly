using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Models.Identity_Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        { 
            _context.Dispose();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers(string query=null)
        {
            var customerQuery = _context.Customers
                            .Include(c => c.MembershipType);


            if (!String.IsNullOrWhiteSpace(query))
                customerQuery = customerQuery.Where(c => c.Name.Contains(query));

             var cutomersDto = customerQuery
                               .ToList()
                               .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(cutomersDto);
        }
        //GET /api/customers
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer,CustomerDto>( customer));
        }

        //Post /api/customers 
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto); 
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }
        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id,CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb==null)
            {
                return NotFound();
            }

            Mapper.Map(customerDto, customerInDb);

            /*
             *                  Alternativly Use Auto mapper
             */
            _context.SaveChanges();
            return Ok();
        }
        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb==null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }


    }
}