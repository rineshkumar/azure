using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace mrrkazure.blobclient
{
    public class Program
    {
        public static async Task Main()
        {
            //Get the connection string 
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            //Create blob service client using conneciton string 
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            string containerName= "mrrkcontainer"+Guid.NewGuid();
            //Create container using blob service client and get blob container client in return 
            BlobContainerClient blobContainerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
            System.Console.WriteLine( blobContainerClient.ToString());
            System.Console.WriteLine(   "Press to continue");
            Console.ReadLine();
                
        }
    }
}