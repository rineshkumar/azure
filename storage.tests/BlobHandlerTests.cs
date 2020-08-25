using Microsoft.VisualStudio.TestTools.UnitTesting;
//THIS IS NOT AN IDEAL UNIT TESTING CLASS\
///Resource group, Storage Account , Container should be created in advance . 
//az group create -l westus -n mrrkrg
//az storage account create --name mrrksa --resource-group mrrkrg --location westus --sku Standard_LRS
//az storage account show-connection-string --name mrrksa --resource-group mrrkrg --subscription <YourSubscription>
//az storage container create -n mrrkstoragecontainer --public-access blob  --account-name mrrksa

namespace storage.tests
{
    [TestClass]
    public class BlobHandlerTests
    {
        [TestMethod]
        public void LoadBlob()
        {
            //Arrange
            string fileName = "/home/rineshkumar/technical/rough/azure/plane.jpg";
            BlobHandler blobHandler = GetBlobHandler();
            //Act
            blobHandler.uploadFile(fileName, fileName);
            //Assert
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void DownloadBlob()
        {
            //Arrange
            string fileName = "/home/rineshkumar/technical/rough/azure/plane.jpg";
            BlobHandler blobHandler = GetBlobHandler();
            //Act
            blobHandler.downloadFile(fileName, fileName, "/home/rineshkumar/technical/rough/azure/planeDownloaded.jpg");
            //Assert
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void ListBlobs()
        {
            //Arrange

            BlobHandler blobHandler = GetBlobHandler();
            //Act
            var list = blobHandler.listBlobs();
            //Assert
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void DeleteBlob()
        {
            //Arrange

            BlobHandler blobHandler = GetBlobHandler();
            //Act
            blobHandler.deleteBlob("plane.jpg");
            //Assert
            Assert.IsTrue(true);
        }


        private static BlobHandler GetBlobHandler()
        {
            string connectionString = "DefaultEndpointsProtocol=https;EndpointSuffix=core.windows.net;AccountName=mrrksa;AccountKey=OegAOhEmFa/WgWUr8vxZHG0OIgOm4/X8yzsLsihPT9O8625knUBy9gBXqsqJvLuYkMFquWOTPP2xHiMWYYWe9A==";
            string containerName = "mrrkstoragecontainer";
            BlobHandler blobHandler = new BlobHandler(connectionString, containerName); ;
            return blobHandler;
        }





    }
}
