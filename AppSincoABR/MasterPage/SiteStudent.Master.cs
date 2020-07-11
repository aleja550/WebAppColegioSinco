using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSincoABR.MasterPage
{
    public partial class SiteTeacher : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadStyleSheet();

            if (Session["Usuario"] == null || Session["Usuario"] != Session["Usuario"])
            {
                Response.Redirect("../Login.aspx");
            }
              
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("../Login.aspx");
                }                   
            }                
        }
        protected void ButtonLogout_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../Login.aspx");
            Response.AppendHeader("Cache-Control", "no-store");
        }

        protected void LoadStyleSheet()
        {
            switch (Session["FkCodigoTemplate"])
            {
                case "0":
                    LinkCss.Attributes.Add("href", "Styles/MasterStyle.css");
                    break;

                case "1":
                    LinkCss.Attributes.Add("href", "Styles/MasterStyle.css");
                    break;

                case "2":
                    LinkCss.Attributes.Add("href", "Styles/GreenTheme.css");
                    break;

                case "3":
                    LinkCss.Attributes.Add("href", "Styles/YellowTheme.css");
                    break;
                default:
                    LinkCss.Attributes.Add("href", "Styles/MasterStyle.css");
                    break;
            }
        }
    }
}