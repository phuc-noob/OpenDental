using Migration.Domain;
using Migration.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.DAO
{
   class PatientDaoOD
   {
      public static List<PatientDomain> Gets()
      {
         var dt = Database.MongoDatabase.Gets("patient");
         List<PatientDomain> resul = new List<PatientDomain>();
         foreach (DataRow dr in dt.Rows) { resul.Add(new PatientDomain(dr)); }
         return resul;
      }
   }
}
