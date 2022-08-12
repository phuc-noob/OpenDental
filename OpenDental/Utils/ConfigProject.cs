using Migration.Const;
using Migration.Conversion;
using Migration.DAO;
using Migration.Manager;
using MigrationUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Migration.Utils
{
   public class Config
   {
      public static ConfigProject Manager;
      public static ProjectMapManager Map;

      public class ProjectMapManager : MapManager
      {
         [MapData(MIGRATE.PROVIDER)]
         public Dictionary<string, long> s_providerMap = new Dictionary<string, long>();

         [MapData(MIGRATE.PROCEDURE)]
         public Dictionary<string, long> s_ProcedureMap = new Dictionary<string, long>();

         [MapData(MIGRATE.PROCEDURE)]
         public Dictionary<string, string> s_ADACodeMap = new Dictionary<string, string>();

         //[MapData(MIGRATE.PROCEDURE)]
         //public Dictionary<string, ProcedureDto> s_ProcedureObjMap = new Dictionary<string, ProcedureDto>();

         [MapData(MIGRATE.PATIENT)]
         public Dictionary<string, Hashtable> s_patientMap = new Dictionary<string, Hashtable>();
         [MapData(MIGRATE.PATIENT)]
         public Dictionary<string, long> s_patientChartMap = new Dictionary<string, long>(); // use for bridge type ChartId
         [MapData(MIGRATE.PATIENT)]
         public Hashtable s_addressMap = new Hashtable();

         [MapData(MIGRATE.FEESCHEDULE)]
         public Dictionary<string, long> s_feeScheduleMap = new Dictionary<string, long>();

         [MapData(MIGRATE.FEESCHEDULE)]
         public Dictionary<string, string> s_feeNameMap = new Dictionary<string, string>();

         [MapData(MIGRATE.RECALL)]
         public Dictionary<string, long> recallMap = new Dictionary<string, long>();

         [MapData(MIGRATE.TREATMENT)]
         public Dictionary<string, long[]> treatmentKey_IdMap;
      }

      public class ConfigProject : ConfigManager
      {
         public override void InitializeConfigs()
         { }

         public override void InitializeTools()
         {
         }

         public override void InitializeReports()
         {
            #region new

            List<string> tables = ReportUtils.MongoDb.getAllTableName(Database.MongoDatabase).OrderBy(n => n).ToList();
            AssignReport(tables, new Action<int, List<string>>((reportType, listReport) =>
            {
               String folderData = Config.Manager.RunPath + "/data/Export_Data";

               if (reportType == 1)
               {
                  ReportUtils.MongoDb.exportAll(Database.MongoDatabase, folderData);
               }
               else if (reportType == 2)
               {
                  folderData += ReportUtils.getExportTime();
                  foreach (string table in listReport)
                  {
                     ReportUtils.MongoDb.export(Database.MongoDatabase, folderData, table);
                  }
               }
            }));

            #endregion new

            #region old

            //LoadConfig();
            //OdbcConnection odbcConn = Database.CreateConnection();
            //List<string> tables = ReportUtils.OdbcDb.getAllTableName(odbcConn);

            //AssignReport(tables, new Action<int, List<string>>((reportType, listReport) =>
            //{
            //   OdbcConnection oleDbConn = Database.CreateConnection();
            //   String folderData = Config.Manager.RunPath + "/data/Export_Data";

            //   folderData += ReportUtils.getExportTime();

            //   if (listReport != null)
            //      foreach (string tableName in listReport)
            //      {
            //         Logger.log("Exporting table: " + tableName);
            //         Common.Export(folderData, tableName, oleDbConn);
            //      }
            //}));

            #endregion old
         }

         public override void InitializeMigrates()
         {
            AssignMigrate(MIGRATE.PATIENT, () => { Patient.Migrate(); });
         }
      }
   }
}