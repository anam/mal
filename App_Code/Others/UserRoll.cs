using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserRoll
/// </summary>
public class UserRoll
{
	public UserRoll()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public UserRoll(string isactive,string roll)
    {
        this.IsActive = isactive;
        this.Roll = roll;
    }
    private string _isactive;
    public string IsActive
    {
        get
        {
            return _isactive;
        }
        private set
        {
            _isactive = value;
        }
    }
    private string _roll;
    public string Roll
    {
        get
        {
            return _roll;
        }
        private set
        {
            _roll = value;
        }
    }
}
