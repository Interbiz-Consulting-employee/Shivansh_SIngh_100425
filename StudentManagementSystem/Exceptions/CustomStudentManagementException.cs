using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.Exceptions
{
      public class StudentValidationException : Exception
        {
            public StudentValidationException()
            {
            }

            public StudentValidationException(string message)
                : base(message)
            {
            }

        }
}
