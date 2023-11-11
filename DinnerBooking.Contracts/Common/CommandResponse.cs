using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Contracts.Common
{
    public class CommandResponse 
    {
      
        public CommandResponse()
        {
            CustomErrors = new List<string>();
        }

        public object? Results { get; set; }
        public long TotalCount { get; set; }
        public List<string> CustomErrors { get; set; }

    }
}
