using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AYTO_BYS_Projesi
{
    public class CustomTextBox : TextBox
    {
        private string customText = "";
        Label customLabel = new Label();

        public CustomTextBox()
        {
            customLabel.Click += new System.EventHandler(customLabel_Click);
            customLabel.Location = new Point(2, 1);
            customLabel.AutoSize = true;
            customLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            customLabel.BackColor = Color.Transparent;
            customLabel.ForeColor = Color.Gray;
            base.Controls.Add(customLabel);
        }
        
        public Font CustomTextFont
        {
            get
            {
                return customLabel.Font;
            }
            set
            {
                customLabel.Font = value;
            }
        }

        public string CustomText
        {
            get
            {
                return customText;
            }
            set
            {
                this.customText = value;
                base.ForeColor = Color.Gray;
                customLabel.Text = customText;
                if (value != "")
                    base.Controls.Add(customLabel);
                customLabel.Location = new Point(2, 1);
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (base.Text == "")
                base.Controls.Add(customLabel);
        }

        public void customLabel_Click(object sender, EventArgs e)
        {
            base.Focus();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if(base.Text != "")
            {
                base.Controls.Remove(customLabel);
            }
            else
            {
                if (this.CustomText != "")
                    base.Controls.Add(customLabel);
            }
        }
    }
}
