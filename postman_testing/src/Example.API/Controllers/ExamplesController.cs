using System;
using System.Collections.Generic;
using System.Web.Http;
using Example.API.Models;
using Serilog;

namespace Example.API.Controllers
{
    public class ExamplesController : ApiController
    {
        // GET: api/Examples
        public IEnumerable<ExampleModel> Get()
        {
            return examples;
        }

        // POST: api/Examples
        public IHttpActionResult Post([FromBody]ExampleModel value)
        {
            if (value.State == State.AZ)
            {
                if (value.PolicyCount >= 1 && value.PolicyCount <= 4)
                {
                    if (value.LoanType == LoanType.LoanModification && value.PolicyCount >= 1 && value.PolicyCount <= 3||
                        value.LoanType == LoanType.Refinance && value.PolicyCount <= 2 ||
                        value.LoanType == LoanType.Purchase && value.PolicyCount >= 3)
                    {
                        if (value.IsVal)
                        {
                            Log.Logger.Information($"Created value {value}");
                            examples.Add(value);
                            return Created($"api/Examples/{value.PolicyCount}", value); 
                        }
                        Log.Logger.Information($"Ignored value {value}");
                        return Ok();
                    }
                }
            }
            Log.Logger.Information($"Did not match expected logic, is this an error?");
            throw new NotImplementedException("Error, does not compute");
        }


        private readonly HashSet<ExampleModel> examples = new HashSet<ExampleModel>() {new ExampleModel {IsVal = true, LoanType = LoanType.LoanModification, PolicyCount = 7, State = State.AZ} };
    }
}
