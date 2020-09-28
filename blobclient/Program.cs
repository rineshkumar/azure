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
            string containerName = "mrrkcontainer" + Guid.NewGuid();
            //Create container using blob service client and get blob container client in return 
            BlobContainerClient blobContainerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
            System.Console.WriteLine(blobContainerClient.ToString());
            System.Console.WriteLine("Press to continue");
            // Console.ReadLine();
            string localPath = "./data";
            string fileName = "mrrkfile" + Guid.NewGuid() + ".txt";
            string localFilePath = Path.Combine(localPath + fileName);
            await File.WriteAllTextAsync(localFilePath, "Hello World");
            var blobClient = blobContainerClient.GetBlobClient(fileName);
            System.Console.WriteLine("Uploading {0} to blob storage as {1} ", fileName, blobClient.Uri);
            using (var fileStreamForupload = File.OpenRead(localFilePath))
            {
                await blobClient.UploadAsync(fileStreamForupload, true);
            }
            var downloadFilePath = localFilePath.Replace(".txt", ".download.txt");
            BlobDownloadInfo download = await blobClient.DownloadAsync();
            using (FileStream fileStreamForWriting = File.OpenWrite(downloadFilePath))
            {
                await download.Content.CopyToAsync(fileStreamForWriting);
            }
            System.Console.WriteLine("Press any key to delete the container ");
            Console.ReadLine();
            await blobContainerClient.DeleteAsync();
            File.Delete(localFilePath);
            File.Delete(downloadFilePath);
            System.Console.WriteLine(   "Done");
        }
    }
}
