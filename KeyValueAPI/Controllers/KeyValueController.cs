using KeyValueAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace KeyValueAPI.Controllers;
    
[ApiController]
[Route("[controller]")]
public class KeyValueController : ControllerBase
{
    // creating a private readonly field for the DataContext
    private readonly DataContext _dataContext;

    // injecting the DataContext into the constructor
    public KeyValueController(DataContext Context)
    {
        _dataContext = Context;
    }
    [HttpGet("{key}")]
    // Creating a method to get value using key and returning the value as a string
    public async Task<IActionResult> Get(string key)
    {
        // using the FindAsync method to find the key in the database 
        var keyValue = await _dataContext.KeyValues.FindAsync(key);
        if (keyValue == null)
        {
            return NotFound(); // if the key is not found, return a 404
        }

        return Ok(keyValue); 
    }
    //[HttpPut]
    [HttpPost]
    public async Task<IActionResult> AddOrUpdate([FromBody] KeyValue keyValue)
    {
        var existingKeyValue = await _dataContext.KeyValues.FindAsync(keyValue.Key);

        if (existingKeyValue != null)
        {
            return Conflict(); // if the key already exists, return a 409
        }

        // adding the key and value to the database
        _dataContext.KeyValues.Add(keyValue);
        await _dataContext.SaveChangesAsync(); 

        return Ok();
    }

    [HttpPatch("{key}/{value}")]

    // Creating a method to update the value using the key 
    public async Task<IActionResult> Update(string key, string value) 
    {
        var keyValue = await _dataContext.KeyValues.FindAsync(key);

        if (keyValue == null)
        {
            return NotFound();
        }
        // updating the value
        keyValue.Value = value;
        await _dataContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{key}")]
    public async Task<IActionResult> Delete(string key)
    {
        var keyValue = await _dataContext.KeyValues.FindAsync(key);

        if (keyValue == null)
        {
            return NotFound();
        }

        // deleting the key and value from the database
        _dataContext.KeyValues.Remove(keyValue);
        await _dataContext.SaveChangesAsync();

        return Ok();
    }
}
