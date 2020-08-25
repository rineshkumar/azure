using System;
using System.IO;
using System.Linq;
using Azure.Storage.Blobs;

namespace storage
{
    public class BlobHandler
    {
        private string connectionString;
        private string containerName;
        private string blobName;

        public BlobHandler(string connectionString, string containerName)
        {
            this.connectionString = connectionString;
            this.containerName = containerName;
        }

        public void uploadFile(string fileName, string blobName)
        {
            BlobContainerClient container = GetContainerClient();
            //container.Create();
            BlobClient blob = container.GetBlobClient(blobName);
            blob.Upload(fileName);
            
        }
        public System.Collections.Generic.List<string> listBlobs()
        {
            var blobs = GetContainerClient().GetBlobs();
           return blobs.Select(x => x.Name).ToList();
            
        }

        private BlobContainerClient GetContainerClient()
        {
            return new BlobContainerClient(connectionString, containerName);
        }

        public void  downloadFile(string fileName, string blobName,string downloadPath)
        {
            using (FileStream downloadFileStream = File.OpenWrite(downloadPath))
            {
                GetContainerClient().GetBlobClient(blobName).DownloadTo(downloadFileStream);
                downloadFileStream.Close();
            }
        }

        public void deleteBlob(string blobName)
        {
            GetContainerClient().GetBlobClient(blobName).Delete();
            GetContainerClient().Delete();
        }
    }
}
