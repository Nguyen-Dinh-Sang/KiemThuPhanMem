using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerals
{
    public class Program
    {
        public double sum(double num1, double num2)
        {
            
            return num1 + num2;
             
        }

        public double subtract (double num1, double num2)
        {
            return num1 - num2; 
        }

        public double multiply (double num1, double num2)
        {
            return num1 * num2; 
        }

        public double divice (double num1, double num2)
        {
            return num1 / num2; 
        }

        public int factorize (int n)
        {
            int factorize = 1;
            for(int i =2; i<=n; i++)
            {
                factorize *= i; 
            }
            return factorize; 
        }

        public int isPrime(int n)
        {
            int dem = 0; 
            for(int i= 1; i<=n; i++)
            {
                if( n % i == 1)
                {
                    dem++; 
                }
            }
            if (dem == 2)
                return 1;
            else
                return 0; 
        }

        public int isPalindrome (int n)
        {
            int sum = 0;
            int r,t;
            for( t = n; n!=0; n = n / 10)
            {
                r = n % 10;
                sum = sum * 10 + r; 
            }
            if (t == sum)
            {
                return 1; 
            }else
            {
                return 0;
            }
        }

        public int isPerfectNumber(int n)
        {
            int sum = 0; 
            for(int i=1; i< n; i++)
            {
                if (n % i == 0)
                {
                    sum += i; 
                }
            }
            if (sum == n)
            {
                return 1; 
            }
            else
            {
                return 0;
            }
        }
        static void Main(string[] args)
        {


        }
    }

}
