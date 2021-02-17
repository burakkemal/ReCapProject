using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message): base (false,message) // base class'a göndermek istediğimiz true ve message base classa göndeririz.
        {

        }
        public ErrorResult():base(false) //default döndürmek
        {

        }
    }
}
