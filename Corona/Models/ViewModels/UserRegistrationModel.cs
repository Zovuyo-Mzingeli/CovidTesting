using Microsoft.AspNetCore.Mvc.Rendering;
using Corona.Enums;
using Corona.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Corona.Models.ViewModels
{
    public class UserRegistrationModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Surname")]
        public string LastName { get; set; }
       
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name ="Confirm Your Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string DepartmentId { get; set; }
        public string ClinicId { get; set; }
        public string HospitalId { get; set; }

        public List<SelectListItem> TitleType { get; set; }
        public UserRegistrationModel()
        {
            TitleType = new List<SelectListItem>();

            TitleType.Add(new SelectListItem
            {
                Value = ((int)Title.Mr).ToString(),
                Text = Title.Mr.ToString()
            });
            TitleType.Add(new SelectListItem
            {
                Value = ((int)Title.Mrs).ToString(),
                Text = Title.Mrs.ToString()
            });
            TitleType.Add(new SelectListItem
            {
                Value = ((int)Title.Miss).ToString(),
                Text = Title.Miss.ToString()
            });
            TitleType.Add(new SelectListItem
            {
                Value = ((int)Title.Dr).ToString(),
                Text = Title.Dr.ToString()
            });
        }
    }
}
