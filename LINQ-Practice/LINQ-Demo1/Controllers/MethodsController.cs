using LINQ_Demo1.Contracts;
using LINQ_Demo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LINQ_Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MethodsController : ControllerBase
    {
        private readonly ILinqMethodsServices _services;
        public MethodsController(ILinqMethodsServices services)
        {
            this._services = services; 
        }

        [HttpGet]
        public async Task<LinqMethodsResultDto> GetAllLinqMethodsResults()
        {
            var result = new LinqMethodsResultDto
            {
                AllMethodResult = await _services.AllMethod(),
                AnyMethodResult = await _services.AnyMethod(),
                AppendMethodResult = await _services.AppendMethod(),
                AverageMethodResult = await _services.AverageMethod(),
                ConcatMethodResult = await _services.ConcatMethod(),
                ContainsMethodResult = await _services.ContainsMethod(),
                CountMethodResult = await _services.CountMethod(),
                //DefaultIfEmptyMethodResult = await _services.DefaultIfEmptyMethod(),
                ElementAtMethodResult = await _services.ElementAtMethod(),
                ElementAtOrDefaultMethodResult = await _services.ElementAtOrDefaultMethod(),
                FirstMethodResult = await _services.FirstMethod(),
                FirstOrDefaultMethodResult = await _services.FirstOrDefaultMethod(),
                GroupByMethodResult = await _services.GroupByMethod(),
                JoinMethodResult = await _services.JoinMethod(),
                //LastMethodResult = await _services.LastMethod(),
                //LastOrDefaultMethodResult = await _services.LastOrDefaultMethod(),
                MaxByMethodResult = await _services.MaxByMethod(),
                MinByMethodResult = await _services.MinByMethod(),
                OrderByDescendingMethodResult = await _services.OrderByDescendingMethod(),
                OrderByMethodResult = await _services.OrderByMethod(),
                PrependMethodResult = await _services.PrependMethod(),
                ReverseMethodResult = await _services.ReverseMethod(),
                SelectManyMethodResult = await _services.SelectManyMethod(),
                SelectMethodResult = await _services.SelectMethod(),
                SkipLastMethodResult = await _services.SkipLastMethod(),
                SkipMethodResult = await _services.SkipMethod(),
                SumMethodResult = await _services.SumMethod(),
                TakeLastMethodResult = await _services.TakeLastMethod(),
                TakeMethodResult = await _services.TakeMethod(),
                ToListMethodResult = await _services.ToListMethod(),
                WhereMethodResult = await _services.WhereMethod()
            };

            return result;
        }


    }
}
