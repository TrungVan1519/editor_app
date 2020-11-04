using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_Videos_Audios_Images.Classes
{
    class MyException : ApplicationException
    {
        public MyException()
        {

        }

        public MyException(string Message) : base(Message)
        {

        }
    }
}
