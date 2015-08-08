using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public class COMN_CommonManager
{
    public COMN_CommonManager()
	{
	}

    public static DateTime convertDate(string date)
    {
        return DateTime.Parse(date.Split('/')[1] + "/" + date.Split('/')[0] + "/" + date.Split('/')[2]);
    
    }

    public static void Paggination(System.Web.UI.WebControls.Repeater rptPager, int recordCount, int currentPage, int PageSize)
    {
        double dblPageCount = (double)((decimal)recordCount / decimal.Parse(PageSize.ToString()));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        List<ListItem> pages = new List<ListItem>();
        if (pageCount > 0)
        {
            pages.Add(new ListItem("First", "1", currentPage > 1));
            pages.Add(new ListItem("Previous", (currentPage - 1).ToString(), currentPage > 1));

            var page_show = 6;
            var both_side_page_show = page_show / 2;


            var show_bellow_limit = currentPage - both_side_page_show;
            var show_top_side_limit = pageCount - both_side_page_show;


            var show_bellow_lower_limit = currentPage - both_side_page_show;
            var show_bellow_top_upper_limit=0;
            if (show_bellow_lower_limit <= 0)
            {
                show_bellow_lower_limit = 1;
                show_bellow_top_upper_limit = show_bellow_lower_limit + both_side_page_show;
            }
            else
            {
                show_bellow_lower_limit = currentPage;
                 show_bellow_top_upper_limit = currentPage + both_side_page_show;
            }



            var show_top_upper_limit = pageCount - both_side_page_show;
            var show_top_lower_limit = show_top_upper_limit - both_side_page_show;


            var do_no = 0;
            for (int i = 1; i <= pageCount; i++)
            {



                if (
                    ((i >= show_bellow_lower_limit) && (i <= show_bellow_top_upper_limit))
                    ||
                    ((i <= show_top_upper_limit) && (i >= show_top_lower_limit))
                    )
                {

                    pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
                    if ((do_no == 0) && (i >= show_bellow_top_upper_limit))
                    {
                        pages.Add(new ListItem("...", i.ToString(), i != currentPage));
                        do_no++;
                    }

                }
            }
            pages.Add(new ListItem("Next", (currentPage + 1).ToString(), currentPage < pageCount));
            pages.Add(new ListItem("Last", pageCount.ToString(), currentPage < pageCount));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }

}

