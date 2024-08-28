using Imagekit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Imagekit;
using Imagekit.Sdk;
using System.Threading.Tasks;
using Org.BouncyCastle.Utilities;
namespace BookFair.Classes
{
    public class ImageUploader
    {

        private static ImagekitClient imagekit = new ImagekitClient("public_2/2EQaff9Z8j1jW6e27c0olIqfw=", "private_zCbmV7ZkcsDDZALmesNJcfTSIL4=", "https://ik.imagekit.io/88upatphat");
        public static Transformation trans = new Transformation()
        .Width(400)
        .Height(300)
        .AspectRatio("4-3")
        .Quality(40)
        .Crop("force").CropMode("extract").
        Focus("left").
        Format("jpeg");


        private static async Task<string> uploadImage(byte[] imageArray)
        {
            try
            {
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                // Upload by Base64
                FileCreateRequest ob2 = new FileCreateRequest
                {
                    file = base64ImageRepresentation,
                    fileName = Guid.NewGuid().ToString()
                };
                Result resp = await imagekit.UploadAsync(ob2);
                return resp.url;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static async Task<string> uploadImageUsingByte(byte[] imageArray)
        {
            try
            {
                string url = await uploadImage(imageArray);
                return url;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static async Task<string> uploadImageUsingPath(string FilePath)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(FilePath);

            string url = await uploadImage(imageArray);
            return url;
        }
    }





}