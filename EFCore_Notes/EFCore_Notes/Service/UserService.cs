using EFCore_Notes.Data;
using EFCore_Notes.Models;
using EFCore_Notes.Repository;
using EFCore_Notes.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Notes.Service
{
    internal class UserService
	{
		private readonly UnitOfWork unitOfWork;

		public UserService(UnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public User Regestration(string[] userInformation)
		{
			string userName = userInformation[0];
			string userEmail = userInformation[1];
			string userPassword = userInformation[2];

			return new User() { UserName = userName, Email = userEmail, Password = userPassword };
		}

		public void EnterToAccount(string[] userNameAndPaasword)
		{ 
			string userName = userNameAndPaasword[0];
			string password = userNameAndPaasword[1];

			var user = unitOfWork.UserRepository.GetAll().FirstOrDefault(x => x.UserName.ToLower() == userName.ToLower() && x.Password == password);

			if (user != null)
				MenuService.SubMenu(unitOfWork, user);	
			else
				Console.WriteLine("User not found");
		}
	}
}