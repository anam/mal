using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;

public class Time
{
    public Time()
    {
    }


    public int  TimeID
    {
        get ; 
        set  ;
    }

    public string  TimeName
    {
        get ; 
        set  ;
    }

   
   
}

public class TimeList
{

    public TimeList()
    { }

   public List<Time> getTimeList()
   {

       List<Time> listOfTime = new List<Time>();

       int startHour = 0;
       int endHour = 23;

       int id = 1;
       for (int h = startHour; h <= endHour; h++)
       {
           for (int m = 0; m < 60; m++)
           {
               if (m % 5 == 0)
               {
                   Time time = new Time();
                   time.TimeID = id++;
                   time.TimeName =  (h>=12?(h-12):h).ToString() + ":" + (m<10?"0":"")+ m.ToString()+" "+(h>=12?"PM":"AM");
                   listOfTime.Add(time);
               }
           }
       }

           return listOfTime;
   }
}

