using Property365.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Core
{
    public sealed record InvalidProductNameError() : Error("The specified product name is invalid");


    public sealed record TransferDateIsPastError()
    : Error("Transfer date cannot be in the past");
    public static class Errors
    {
        public static Error InvalidSchemeName => new InvalidProductNameError();
      
    }
}
