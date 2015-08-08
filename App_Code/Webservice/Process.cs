using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for DailyProcess
/// </summary>
[WebService(Namespace = "http://web.mavrickit.com/cuc/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Process : System.Web.Services.WebService {

    public Process()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public string HourlyProcess()
    {
        ACC_AccountingCommonManager.ProcessDataBackupAuto();
        return "Process Success Fully run";
    }
    
}
