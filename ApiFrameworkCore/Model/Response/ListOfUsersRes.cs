using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiFrameworkCore.Model.Response
{
	public class ListOfUsersRes
	{
		

        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Datum> data { get; set; }
        public Support support { get; set; }
      
	}

  
}

