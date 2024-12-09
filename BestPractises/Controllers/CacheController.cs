﻿using BestPractises.Interfaces;
using BestPractises.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BestPractises.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IRedisCacheService _redisCacheService;

        public CacheController(IRedisCacheService redisCacheService)
        {
            _redisCacheService = redisCacheService;
        }
        [HttpGet("cache/{key}")]
        public async Task <IActionResult>Get (string key)
        {
           
            return Ok(await _redisCacheService.GetValueAsync(key));

        }
        [HttpPost("cache/set")]
        public async Task<IActionResult> Set([FromBody] RedisCacheRequestModel redisCacheRequestModel)
        {
            await _redisCacheService.SetValueAsync(redisCacheRequestModel.Key, redisCacheRequestModel.Value);
            return Ok();
        }

        [HttpDelete("cache/{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            await _redisCacheService.Clear(key);
            return Ok();
        }
    }
}