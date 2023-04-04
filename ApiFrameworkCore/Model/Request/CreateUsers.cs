using System;
using System.Text.Json.Serialization;

namespace ApiFrameworkCore.Model.Request
{
	public class CreateUsers
	{

		[JsonPropertyName("name")]
		public string names { get; set; }
		public string job { get; set; }
    
	}
}

