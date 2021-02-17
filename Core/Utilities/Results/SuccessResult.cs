using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(false, message) // base class'a göndermek istediğimiz true ve message base classa göndeririz.
        {

        }
        public SuccessResult() : base(false) //default döndürmek
        {

        }
    }
}
