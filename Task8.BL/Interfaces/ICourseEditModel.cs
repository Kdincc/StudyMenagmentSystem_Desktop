using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface ICourseEditModel
    {
        public IEnumerable<Group> Groups { get; }

        public void BuildDocxGroupList(string path);

        public void BuildPDFGroupList(string path);

        public void CreateGroup(string groupName);

        public void RemoveGroup(Group group);

        public void InitCourse(Course course);

        public void SaveChanges();
    }
}
