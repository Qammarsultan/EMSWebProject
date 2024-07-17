﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EMSWebProject.Models
{
    public class EmployeeInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }

        
    }
}
