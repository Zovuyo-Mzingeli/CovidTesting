using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModels
{
	public class RoleViewModel
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string PhoneNumber { get; set; }
		public string ClinicId { get; set; }
		public string ProfileImage { get; set; }
		public Dictionary<string, string> Roles { get; set; } = new Dictionary<string, string>();
	}
}