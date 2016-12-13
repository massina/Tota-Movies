using AutoMapper;
using System;
using System.Linq;
using System.Web.Http;
using TotaMoviesRental.Core;
using TotaMoviesRental.Core.Dtos;
using TotaMoviesRental.Core.Models;

namespace TotaMoviesRental.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customerDtos = _unitOfWork.Customers
                .GetCustomersWithMembershipTypes(query)
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _unitOfWork.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Complete();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customerInDb = _unitOfWork.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);

            _unitOfWork.Complete();
            return Ok();
        }

        // DELETE /api/cusomer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = _unitOfWork.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            _unitOfWork.Customers.Remove(customer);
            _unitOfWork.Complete();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
        }
    }
}
