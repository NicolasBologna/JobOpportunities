using JobOpportunities.Core.Comparers;
using System.Security.Cryptography;

namespace JobOpportunities.Domain
{
    public class Seniority : EntityBase
    {
        public Seniority(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public string? Description { get; set; }

        public static bool operator ==(Seniority? x, Seniority? y)
        {
            SeniorityComparer comparer = new SeniorityComparer();
            return comparer.Equals(x, y);
        }

        public static bool operator !=(Seniority? x, Seniority? y)
        {
            return !(x == y);
        }
    }
}
