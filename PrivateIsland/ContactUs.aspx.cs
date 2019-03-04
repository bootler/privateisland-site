using System;

namespace PrivateIsland
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string nameSaveBTN = TextBoxName.Text;
                string lastNameSaveBTN = TextBoxLastName.Text;
                string phoneNumberSaveBTN = TextBoxPhone.Text;
                string emailSaveBTN = TextBoxEmail.Text;
                string inquirySaveBTN = DropDownListInquiry.SelectedValue;
                string methodContact = RadioButtonListMethod.SelectedValue;
                string message = TextBoxMessage.Text;

                Info infoSaveBTN = new Info(nameSaveBTN, lastNameSaveBTN, phoneNumberSaveBTN, emailSaveBTN, inquirySaveBTN, methodContact, message);
                ConnectionClass.AddInfo(infoSaveBTN);
                LabelDB.Text = "Uploaded Successfully!";
            }
            catch
            {
                LabelDB.Text = "Upload Failed!";
            }
        }
    }
}
