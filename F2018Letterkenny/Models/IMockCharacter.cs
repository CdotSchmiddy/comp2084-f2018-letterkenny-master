using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F2018Letterkenny.Models
{
    public interface IMockCharacter
    {
        IQueryable<Character> Characters { get; }
        Character Save(Character character);
        void SaveChanges();
        object Entry(Character character);
    }
}
