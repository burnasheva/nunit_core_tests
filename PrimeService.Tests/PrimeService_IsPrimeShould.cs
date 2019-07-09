using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [Test]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _primeService.IsPrime(1);

            Assert.IsFalse(result, $"1 should not be prime");
        }
        
        [TestCase(2)]
        [TestCase(0)]
        [TestCase(1)]
        public void ReturnFalseGivenValuesLessThan2(int value)
        {
            String path = $"logfile{value}.txt";
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                outputFile.WriteLine($"log message {value}");
            }
            
            Console.WriteLine($"##teamcity[publishArtifacts '{path}']");
            
            var result = _primeService.IsPrime(value);

            Assert.IsFalse(result, $"{value} should not be prime"); 
        }
        
    }
}
