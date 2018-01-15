using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public string projectName;

        public ProjectData(string projectName)
        {
            this.projectName = projectName;
        }

        public ProjectData()
        {
        }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return projectName == other.projectName;
        }


        public override int GetHashCode()
        {
            return projectName.GetHashCode();
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return projectName.CompareTo(other.projectName);
        }

        //public override string ToString()
        //{
        //    return "projectName=" + projectName;
        //}
    }
}
