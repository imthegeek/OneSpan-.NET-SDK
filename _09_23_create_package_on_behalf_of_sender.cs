using Silanis.ESL.SDK;
using Silanis.ESL.SDK.Builder;
using System;
using System.Diagnostics;

namespace FeatureGuideCharp
{
    class _09_23_create_package_on_behalf_of_sender
    {

        public void Execute()
        {
            String apiKey = "your_api_key";
            String apiUrl = "https://sandbox.esignlive.com/api";

            EslClient eslClient = new EslClient(apiKey, apiUrl);

            DocumentPackage pkg = PackageBuilder.NewPackageNamed("New Package")
                   .WithSigner(SignerBuilder.NewSignerWithEmail("signer1@mailinator.com")
                           .WithFirstName("Shruti")
                           .WithLastName("Mukherjee"))
                   .WithDocument(DocumentBuilder.NewDocumentNamed("document 1")
                           .FromFile("your_file_path")
                           .WithSignature(SignatureBuilder.SignatureFor("signer1@mailinator.com")
                                   .OnPage(0)
                                   .AtPosition(100, 100)
                                   .WithSize(250, 75)))
                   .WithSenderInfo(SenderInfoBuilder.NewSenderInfo("your_sender_email"))
                   .WithVisibility(Visibility.ACCOUNT)                  //only works for templates
                   .Build();

            PackageId packageId = eslClient.CreatePackageOneStep(pkg);	//package creation
            //PackageId templateId = eslClient.CreateTemplate(pkg);     //template creation


        }

    }
}
