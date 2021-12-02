﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uber2.Data;
using Uber2.Models;

namespace Uber2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriversController:ControllerBase
    {
        private readonly IDriversService driverService;

        public DriversController(IDriversService driverService)
        {
            this.driverService = driverService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Driver>>> GetDrivers([FromQuery] string? username) 
        {
            try
            {
                IList<Driver> drivers = await driverService.GetDriversAsync();
                if (username != null)
                {
                    drivers = drivers.Where(driver => driver.username == username).ToList();
                }
                return Ok(drivers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult> DeleteDriver([FromRoute] int Id) 
        {
            try
            {
                await driverService.RemoveDriverAsync(Id);
                return Ok();
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Customer>> AddDriver([FromBody] Driver driver) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Driver added = await driverService.RegisterDriverAsync(driver);
                return Created($"/{added.id}",added);
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        [Route("{Id:int}")]
        public async Task<ActionResult<Customer>> UpdateDriver([FromBody] Driver driver) 
        {
            try
            {
                Driver updated = await driverService.EditDriverInfoAsync(driver);
                return Ok(updated); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost("Login")]
        public async Task<ActionResult> LoginDriver([FromBody] Driver driver)
        {
            try
            {
                var result = driverService.Login(driver.username, driver.password);
                if (result.Equals(false))
                {
                    Console.WriteLine("Tier 3 log in failed");
                    return BadRequest(new {message = "Username or password is incorrect"});
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
            return Ok(new {message = "Driver Login success"});
        }
    }
}