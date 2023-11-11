using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Contracts.Common;

public class QueryResponse
{
    public int StatusCode { get; set; }
    public string? ErrorMessage { get; set; }
    public object? Results { get; set; }
    public long TotalCount { get; set; }
}