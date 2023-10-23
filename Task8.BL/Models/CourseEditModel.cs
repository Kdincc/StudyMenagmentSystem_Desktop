using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.BL.Interfaces;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Models
{
    public class CourseEditModel : ICourseEditModel
    {
        public IEnumerable<Group> Groups => throw new NotImplementedException();

        public void BuildDocxGroupList(string path)
        {
            throw new NotImplementedException();
        }

        public void BuildPDFGroupList(string path)
        {
            throw new NotImplementedException();
        }

        public void CreateGroup(string groupName)
        {
            throw new NotImplementedException();
        }

        public void InitCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public void RemoveGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
