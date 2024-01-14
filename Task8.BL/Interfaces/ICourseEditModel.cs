using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface ICourseEditModel : IUpdatable
    {
        public IEnumerable<Group> Groups { get; }

        public IEnumerable<Teacher> Teachers { get; }

        public void CreateGroup(string groupName);

        public void RemoveGroup(Group group);

        public void InitCourse(Course course);

        public void BuildDocxReport(string savePath, Group group);

        public void BuildPDFReport(string savePath, Group group);

        public void ImportStudents(Group group, string csvFilePath);

        public void ExportStudents(Group group, string exportPath);

        public void SaveChangesFor(Group group);
    }
}
