using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KeyValueAPI;
public class KeyValue
{
    // Creating a Keyless attribute for the KeyValue class and setting the Key property as the primary key 
    [Key]
    public string Key { get; set; }
    public string Value { get; set; }
}
