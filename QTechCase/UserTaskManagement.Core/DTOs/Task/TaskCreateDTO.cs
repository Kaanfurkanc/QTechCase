﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTaskManagement.Core.DTOs.Task
{
    public class TaskCreateDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int UserId { get; set; }
    }
}
