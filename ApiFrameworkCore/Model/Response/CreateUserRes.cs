using System;
using System.Text.Json.Serialization;

namespace ApiFrameworkCore.Model.Response
{
	public class CreateUserRes
	{
        
        public string name { get; set; }
        public string job { get; set; }
        public int id { get; set; }
        public DateTime createdAt { get; set; }
    }
}

