using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class ShowVoteInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            bindItemList();
        }
    }
    void bindItemList()
    {
        SqlConnection conn = new SqlConnection("Server=.;database=WebVote;uid=sa;pwd=;");
        conn.Open();
        //建立从数据库中获取数据的命令
        SqlCommand cmd = new SqlCommand("Sp_voteWithPercentage", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        this.gvVoteList.DataSource = cmd.ExecuteReader();
        this.gvVoteList.DataBind();
        conn.Close();
    }

    protected void gvVoteList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int percentage = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "percentage").ToString());
            ((Image)e.Row.FindControl("image1")).Width = new Unit(Convert.ToString(percentage * 3) + "px");
            ((Image)e.Row.FindControl("image1")).Height = new Unit("20px");
        }
    }
}