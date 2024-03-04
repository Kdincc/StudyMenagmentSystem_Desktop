using System.Collections.Generic;
using Task8.Data.Entity.Generated;

namespace Task8.BL.Interfaces
{
    public interface ICourseEditModel
    {
        public Course CurrentCourse { set; }

        public IEnumerable<Group> Groups { get; }

        public IEnumerable<Teacher> Teachers { get; }

        public bool CreateGroup(string groupName);

        public bool RemoveGroup(Group group);

        public void BuildDocxReport(string savePath, Group group);

        public void BuildPDFReport(string savePath, Group group);

        public CsvReadingResults<Student> ImportStudents(Group group, string csvFilePath);

        public void ExportStudents(Group group, string exportPath);

        public void ChangeGroupName(Group groupToChange, string newName);

        public void ChangeGroupTeacher(Group groupToChange, Teacher newTeacher);

        public void SaveChanges();
    }
}
