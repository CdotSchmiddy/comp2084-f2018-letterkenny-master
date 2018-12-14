using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace F2018Letterkenny.Models
{
    public class EFCharacter : IMockCharacter
    {
        private DatabaseModel db = new DatabaseModel();
        IQueryable<Character> IMockCharacter.Characters { get { return db.Characters; } }

        Character IMockCharacter.Save(Character character)
        {
            {
                if (character.CharacterId == 0)
                {
                    db.Characters.Add(character);
                }
                else
                {
                    //update
                    db.Entry(character).State = System.Data.Entity.EntityState.Modified;
                }

                db.SaveChanges();
                return character;
            }
        }
    }
}