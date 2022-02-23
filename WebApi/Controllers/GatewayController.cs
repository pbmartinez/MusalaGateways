﻿using Application.Dtos;
using Application.IAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("api/gateway")]
    public class GatewayController : ApiBaseController<GatewayDto>
    {
        public GatewayController(IGatewayAppService appService, ILogger<ApiBaseController<GatewayDto>> logger)
            : base(appService, logger)
        {
            Includes = new List<Expression<Func<GatewayDto, object>>>() { g => g.Peripherals };
        }
    }
}