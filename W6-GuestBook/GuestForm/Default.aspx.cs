using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GuestForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonAdd_Click(object sender, EventArgs e)
        {
            var gcr = new GuestCommentRepository();
            gcr.AddComment(nameTextbox.Text, commentTextbox.Text);
            nameTextbox.Text = String.Empty;
            commentTextbox.Text = String.Empty;
            gridView.DataBind();
        }
    }
}