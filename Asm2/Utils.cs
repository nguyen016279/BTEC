using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Asm2
{
	public class Utils
	{
		public Utils()
		{

		}
		public static bool checkStudentId(string id)
		{
			return new Regex(@"^GT\d{5}|^GC\d{5}").Match(id).Success;
		}
		public static bool checkLecturerId(string id)
		{
			return new Regex(@"\d{8}").Match(id).Success;
		}
		public static bool checkDateFormat(string date)
		{
			return DateTime.TryParse(date, out _);
		}
		public static bool checkEmail(string email)
		{
			try
			{
				MailAddress m = new MailAddress(email);

				return true;
			}
			catch (FormatException)
			{
				return false;
			}
		}
		public static string askForKeyword(string str)
		{
			Console.WriteLine(str);
			return Console.ReadLine();
		}
	}
}  
