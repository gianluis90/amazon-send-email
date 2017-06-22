using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using System.IO;

namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            //Remember to enter your (AWSAccessKeyID, AWSSecretAccessKey) if not using and IAM User with credentials assigned to your instance and your RegionEndpoint
            using (var client = new AmazonSimpleEmailServiceClient("YourAWSAccessKeyID", "YourAWSSecretAccessKey", RegionEndpoint.USEast1))
            {
                var emailRequest =  new SendEmailRequest()
                {
                    Source = "FROMADDRESS@TEST.COM",
                    Destination = new Destination(),
                    Message = new Message()
                };

                emailRequest.Destination.ToAddresses.Add("TOADDRESS@TEST.COM");
                emailRequest.Message.Subject = new Content("Hello World");
                emailRequest.Message.Body = new Body(new Content("Hello World"));
                client.SendEmail(emailRequest);
            }
        }
    }
}
