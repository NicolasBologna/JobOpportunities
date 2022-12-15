using JobOpportunities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Core.Comparers
{
    internal class SeniorityComparer : EqualityComparer<Seniority>
    {
        public override int GetHashCode(Seniority obj)
        {
            int randomNumber = RandomNumberGenerator.GetInt32(int.MaxValue / 2);
            return (obj.Id.GetHashCode() + obj.Name.Length + randomNumber).GetHashCode();
        }
        public override bool Equals(Seniority? x, Seniority? y)
        {
            if (x is null || y is null) return false;
            return x.Id == y.Id && x.Name == y.Name;
        }
    }
}
