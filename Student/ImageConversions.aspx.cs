using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class ImageConversions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CreatePhoto();
    }

    void CreatePhoto()
    {
        try
        {
            string strPhoto = Request.Form["imageData"]; //Get the image from flash file
            byte[] photo = Convert.FromBase64String(strPhoto);

            string dirUrl = "~/Uploads/cuc_Picture/";
            string dirPath = Server.MapPath(dirUrl);


            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            FileStream fs = new FileStream(dirPath+"St_Pic.jpg", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter br = new BinaryWriter(fs);
            br.Write(photo);
            br.Flush();
            br.Close();
            fs.Close();

            string camimg = dirPath + "St_Pic.jpg";
            
            Session["imagePath"] = camimg;

            
        }
        catch (Exception Ex)
        {
            
        }
    }
}
