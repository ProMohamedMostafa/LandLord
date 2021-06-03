using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GenieLandLoardSolution.Models;
using GenieLandLoardSolution.BL;

namespace GenieLandLoardSolution.Controllers
{
    [Route("~/api/[controller]/[action]")]
    [ApiController]
    [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
    public class TbLandLoardsController : ControllerBase
    {
        private readonly GenieDBlandLoardContext _context;
        private readonly IBusinessLayer _businessLayer;

        public TbLandLoardsController(GenieDBlandLoardContext context,
                                      IBusinessLayer businessLayer)
        {
            _context = context;
            _businessLayer = businessLayer;
        }

        // get record of company with it's Domain
        [HttpGet]
        [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
        [Route("~/api/TbLandLoards/GetTbLandLoard")]
        public async Task<ActionResult<TbLandLoard>> GetTbLandLoard(string domain)
        {
            var company =await _businessLayer.GetTbLandLoard(domain);
            if (company == null)
            {
                return Ok(null);
            }
            return Ok(company);
            //TbLandLoard landLoardDb = new TbLandLoard();
            //List<TbLandLoard> ls = _context.TbLandLoards.ToList();

            //foreach(TbLandLoard item in ls)
            //{
            //    if (item.Domain == domain)
            //    {
            //        landLoardDb = item;
            //        break;
            //    }

            //}
            ////var tbLandLoard = await _context.TbLandLoards.FindAsync(id);

            //if (landLoardDb == null)
            //{
            //    return NotFound();
            //}

            //return landLoardDb;
        }

       [HttpPut("{id}")]
        public async Task<IActionResult> PutTbLandLoard(int id, TbLandLoard tbLandLoard)
        {
            if (id != tbLandLoard.Id)
            {
                return BadRequest();
            }

            //_context.Entry(tbLandLoard).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            try
            {
                var update = _businessLayer.PutTbLandLoard(id , tbLandLoard);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!TbLandLoardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw ex;
                }
            }

            return NoContent();
        }

        // create new record in LandLoard table
        [HttpPost]
        [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
        [Route("~/api/TbLandLoards/PostTbLandLoard")]
        public async Task<ActionResult<TbLandLoard>> PostTbLandLoard([FromBody] TbLandLoard tbLandLoard)
        {
            try
            {
                var updateRecord =await _businessLayer.PostTbLandLoard(tbLandLoard);
                return CreatedAtAction("GetTbLandLoard", new { id = updateRecord.Id }, updateRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Data);
            }
          
        }

        // DELETE record from table LandLoard
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbLandLoard(int id)
        {
            var Result = await _businessLayer.DeleteTbLandLoard(id);
            if (Result == false)
            {
                return Ok("Delete record filled");
            }
            return Ok();
        }

        // check if record of this domain Exist or no
        private bool TbLandLoardExists(int id)
        {
            var recordExist = _businessLayer.TbLandLoardExists(id);
            if (recordExist == false)
            {
                return false;
            }
            return true;
        }

    }
}
