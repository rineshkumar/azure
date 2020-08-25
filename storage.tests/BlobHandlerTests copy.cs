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
    public class FileHandlerTests
    {
        [TestMethod]
        public void LoadBlob()
        {
           
        }
        

    }
}
