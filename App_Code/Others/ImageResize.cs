using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

/// <summary>
/// Summary description for ImageResize
/// </summary>
/// 
/// 
namespace SmartDataSoft
{
    public class ImageResize
    {
        public ImageResize()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        /// <summary>
        /// This will generate a thumb image or resized image of the , given file
        /// </summary>
        /// <param name="temp_filePath">where the temporary file will generate. It will delete later by code.</param>
        /// <param name="dirPath">where the original image will saved</param>
        /// <param name="filename">the file which need to save</param>
        /// <param name="thumbnailHeight">It is the height of the new image. which will created.</param>

        /// <returns></returns>
        public string ResizedImage(string temp_filePath, string dirPath, FileUpload file_uploader, int thumbnailHeight, string FileName)
        {
            string temp_fileUrl = temp_filePath + Path.GetFileName(file_uploader.FileName);

            file_uploader.PostedFile.SaveAs(temp_fileUrl);

            string imageName = Path.GetFileName(file_uploader.PostedFile.FileName);

            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(temp_fileUrl);

            int thumbnailWidth = (int)(((double)thumbnailHeight / originalImage.Height) * originalImage.Width); ;

            System.Drawing.Image resizedImage = resizeImageWithGivenValue(originalImage, thumbnailWidth, thumbnailHeight);


            string _strFileName = Path.GetFileName(file_uploader.FileName);
            //getFileName fName = new getFileName(_strFileName, dirPath);
            //var filename_temp_filePath = FileName != "" ? FileName +".Jpeg" : fName.FileName;
            var filename_temp_filePath = FileName + ".Jpeg";// != "" ? FileName + ".Jpeg" : fName.FileName;
            //System.IO.FileInfo file;
            //file = new System.IO.FileInfo(dirPath + FileName + ".Jpeg");
            //if (file.Exists)
            //{
            //    file.Delete();
            //}
            resizedImage.Save(dirPath + filename_temp_filePath, ImageFormat.Jpeg);

            originalImage.Dispose();

            File.Delete(temp_fileUrl);

            return filename_temp_filePath;

        }
        public Bitmap resizeImageWithGivenValue(System.Drawing.Image originalImage, int givenWidth, int givenHeight)
        {
            int sourceImageWidth = originalImage.Width;
            int sourceImageHeight = originalImage.Height;
            int distinationX = 0;
            int distinationY = 0;
            int sourceX = 0;
            int sourceY = 0;
            int resizedImageWidth = givenWidth;
            int resizedImageHeight = givenHeight;
            Bitmap resizedImage = new Bitmap(resizedImageWidth, resizedImageHeight, PixelFormat.Format24bppRgb);
            resizedImage.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);
            Graphics newResizedImage = Graphics.FromImage(resizedImage);
            newResizedImage.InterpolationMode = InterpolationMode.HighQualityBicubic;
            newResizedImage.DrawImage(
                                        originalImage,
                                        new Rectangle(distinationX, distinationY, resizedImageWidth, resizedImageHeight),
                                        new Rectangle(sourceX, sourceY, sourceImageWidth, sourceImageHeight),
                                        GraphicsUnit.Pixel
                                      );
            newResizedImage.Dispose();

            return resizedImage;
        }

    }
    public class getFileName
    {
        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public getFileName(string fileName, string path)
        {
            System.IO.FileInfo file;
            string tmpfileName = fileName.Substring(0, fileName.LastIndexOf("."));
            string ftype = fileName.Substring(fileName.LastIndexOf(".") + 1, fileName.Length - fileName.LastIndexOf(".") - 1);
            int i;
            for (i = 0; ; i++)
            {
                file = new System.IO.FileInfo(path + "//" + tmpfileName + i.ToString() + "." + ftype);
                if (file.Exists)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            FileName = tmpfileName + i.ToString() + "." + ftype;
        }
    }

}
