using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task8.Data.Entity.Generated;

namespace Task8.BL
{
    public class GroupReport
    {
		private readonly string _courseNameHeader;
		private readonly string _groupNameHeadr;
		private readonly List<Student> _students;

        public GroupReport(string courseNameHeader, string _groupNameHeader, List<Student> students)
        {
            _courseNameHeader = courseNameHeader;
            _groupNameHeadr = _groupNameHeader;
            _students = students;
        }

        public IEnumerable<Student> Students => _students;

		public string GroupNameHeader => _groupNameHeadr;

		public string CourseNameHeader => _courseNameHeader;

	}
}
