using Migration.Conversion;
using Migration.DAO;
using Migration.Domain;
using Migration.Manager;
using Migration.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDental
{
    internal class Program
    {
      public static MigrationManager MM;

      [STAThread]
      public static void Main(string[] args)
      {
         MM = new MigrationManager(args, new Config());
         MM.ShowUI();
         Patient.DeletePatient();
      }
   }
}
