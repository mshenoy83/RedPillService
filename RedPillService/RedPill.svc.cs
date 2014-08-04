using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedPillService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(Namespace = "http://KnockKnock.readify.net")]
    public class RedPill : IRedPill
    {

        public long FibonacciNumber(long n)
        {
            long a = 0;
            long b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            if (n > 92)
            {
                var exception = new ArgumentOutOfRangeException();
                throw new FaultException<ArgumentOutOfRangeException>(exception, "Fib(>92) will cause a 64-bit integer overflow.");
            }
            for (long i = 0; i < n; i++)
            {
                long temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

        

        public string ReverseWords(string s)
        {
            string[] strArray = s.Split(' ');
            StringBuilder strBuild = new StringBuilder();
            string sep = "";
            for (var i =0;i<strArray.Length;i++)
            {
                var rev = String.Join("",strArray[i].ToCharArray().Reverse());
                strBuild.Append(sep).Append(rev);
                sep = " ";
            }
            return strBuild.ToString();
           
        }

        
        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            try
            {
                if (a == 1 || b == 1 || c == 1)
                {
                    return TriangleType.Error;
                }

                int iEqualSides = 0;
                if (a == b)
                {
                    iEqualSides++;
                }
                if (a == c)
                {
                    iEqualSides++;
                }

                switch (iEqualSides)
                {
                    case 1:
                        return TriangleType.Isosceles;
                    case 2:
                        return TriangleType.Equilateral;
                    default:
                        return TriangleType.Scalene;
                }
            }
            catch
            {
                return TriangleType.Error;
            }
        }

      


        public ContactDetails WhoAreYou()
        {
            return new ContactDetails
            {
                EmailAddress = @"mshenoy83@gmail.com",
                FamilyName = "Shenoy",
                GivenName = "Madhav",
                PhoneNumber = "+61422027397"
            };
        }


        
    }
}
