﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8.Data.Entity.Generated
{
    public partial class Group
    {
        public Group(Group group)
        {
            Name = group.Name;
            GroupId = group.GroupId;
            Course = group.Course;
            CourseId = group.CourseId;
            Students = group.Students;
        }

        public Group()
        {
            
        }
    }
}
