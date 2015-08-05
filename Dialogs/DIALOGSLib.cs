// Namespace Declaration
using System;
using System.Windows.Forms;

// The DIALOGSLib Namespace
namespace DIALOGSLib
{
   // The NewDialogs class
   class NewDialogs
	{
		public static void DLGNote(string sNotification, string sCaption)
		{
		string notification = sNotification;
		string caption = sCaption;
		MessageBox.Show(notification, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	  public static bool DLGAsk(string sQuestion, string sCaption)
		{
		string question = sQuestion;
		string caption = sCaption;
		var result = MessageBox.Show(question, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
				{
					return true;
				}
			else
				{
					return false;
				}
		}
	  public static bool DLGWarn(string sWarning, string sCaption)
		{
		string warning = sWarning;
		string caption = sCaption;
		var result = MessageBox.Show(warning, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
			if (result == DialogResult.OK)
				{
					return true;
				}
			else
				{
					return false;
				}
		}
	}
}
