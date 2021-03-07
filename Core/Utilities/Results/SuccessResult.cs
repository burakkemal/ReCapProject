using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message) // base class'a göndermek istediğimiz true ve message base classa göndeririz.
        {

        }
        public SuccessResult() : base(true) //default döndürmek
        {

        }
    }
}
