using Microsoft.Azure.Documents;
using System;

namespace brexittravelmoneycalculator.data
{
    class Program
    {

        /// <summary>
        /// The main method for the demo
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            var client = new CurrenciesClient();
            try
            {
                client.SetupDocuments().Wait();
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Console.WriteLine("End, press any key to exit.");
                Console.ReadKey();
            }
        }          
    }
}
