using Migration.DAO;
using Migration.Domain;
using Migration.DTO;
using Migration.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Conversion
{
   internal class Patient
   {
      private static List<PatientDomain> patientList = null;
      public static List<PatientDomain> PatientList
      {
         get
         {
            if (patientList == null)
               patientList = PatientDaoOD.Gets();
            return patientList;
         }
      }

      public static void Migrate()
      {
         
         var listLanguageDto = LanguageDao.gets().Where(x => x.Customer == "GENERAL").ToList();
         

         //Hashtable s_patientReferrerMap = new Hashtable();
         int count = 0, total = PatientList.Count;
         foreach (var patDomain in PatientList)
         {
            count++;

            // Provider Id
            long providerId = 0;
            if (!patDomain.ProvId1.Equals(""))
               providerId = Config.Map.s_providerMap.GetValue(patDomain.ProvId1);
            else if (!patDomain.ProvId2.Equals(""))
               providerId = Config.Map.s_providerMap.GetValue(patDomain.ProvId2);
            if (providerId == 0)
               providerId = Config.Map.s_providerMap.GetValue(Config.Manager.DEFAULT_TREATING_PROVIDER);

            var activeDate = FormatUtils.formatDate(patDomain.FirstVisit);
            

            // Marital status
            

            // Medical Alert
            var medicalAlert = "";
            //var medicalList = MedicalAlert.GetMedicalAlert(patDomain.MedAlertMask1, patDomain.MedAlertMask2);
            //foreach (var med in medicalList)
            //   medicalAlert += med + "; ";
            //if (medicalAlert.Length > 2)
            //   medicalAlert = medicalAlert.Substring(0, medicalAlert.Length - 2);

            // 0: Address, 1: Zipcode, 2: Home Phone
            

            // Middle Initial
            if (patDomain.MI.Length > 1)
               patDomain.MI = patDomain.MI.Substring(0, 1);

            // INSERT PATIENT
            var patientDto = new PatientDto();
            patientDto.PatientKey = patDomain.PatId;
            patientDto.PatientChart = patDomain.ChartNum;
            patientDto.PatientId = patDomain.PatId;

            patientDto.HomePhone = patDomain.OtherPhone ;
            patientDto.LastName = patDomain.LastName;
            patientDto.FirstName = patDomain.FirstName;
            patientDto.Address = patDomain.AddressId;
            // patientDto.ZipCode = TypesUtils.Parse.ToInt32(addZipPhone[1]);
            // patientDto.HomePhone = FormatUtils.formatPhone(addZipPhone[2]);
            patientDto.OfficePhone = FormatUtils.formatPhone(patDomain.WorkPhone);
            patientDto.MobilePhone = FormatUtils.formatPhone(patDomain.Pager);
            patientDto.SSN = FormatUtils.formatSSN(patDomain.SSN);
            patientDto.Email = patDomain.Email;
            if (patientDto.Email.Length > 50)
               patientDto.Email = patientDto.Email.Substring(0, 50);
            patientDto.MiddleInitial = patDomain.MI.Length > 1 ? patDomain.MI.Substring(0, 1) : patDomain.MI;
            // patientDto.Title = ConversionUtils.Patient.Title(patDomain.Title, gender, maritalStatus);
            // patientDto.Gender = gender;
            // patientDto.MaritalStatus = maritalStatus;

            // patientDto.MaritalStatusId = maritalStatusMap.GetValue(patDomain.FamPos);
            //if (patientDto.MaritalStatusId == 0) { patientDto.MaritalStatusId = ISS.PATIENT.DEFAULT_MARITAL_STATUS_ID; }

            patientDto.MedicalAlert = medicalAlert;
            patientDto.TimeZone = Config.Manager.TIME_ZONE;
            patientDto.ProviderId = providerId;
            // patientDto.ResponsibleParty = ISS.PATIENT.RESPONSIBLE_GUARANTOR;
            // patientDto.Coverage = ISS.PATIENT.COVERAGE_NONE;
            // patientDto.DriverLicense = ConversionUtils.Patient.Driverslicense(patDomain.DriversLicense);
            patientDto.Dob = FormatUtils.formatDate(patDomain.BirthDate);
            patientDto.Pager = FormatUtils.formatPhone(patDomain.Pager);
            if (patientDto.Pager.Length > 12) patientDto.Pager = patientDto.Pager.Substring(0, 12);
            patientDto.ActiveDate = activeDate;

            #region Other Info
            if (!string.IsNullOrEmpty(patDomain.Salutation))
            {
               if (!string.IsNullOrEmpty(patientDto.OtherInfo)) { patientDto.OtherInfo += "\n"; }
               patientDto.OtherInfo = "Salutation: " + patDomain.Salutation;
            }
            if (!string.IsNullOrEmpty(patDomain.WkExt))
            {
               if (!string.IsNullOrEmpty(patientDto.OtherInfo)) { patientDto.OtherInfo += "\n"; }
               patientDto.OtherInfo = "Office Ext: " + patDomain.WkExt;
            }
            #endregion

            #region Patient Note
            // Patient Note
            // var lstNote = patientNoteMap[patDomain.PatId] as List<NotesDomain>;
            // var patientNote = ConversionUtils.Patient.PatientNote(lstNote, patDomain, employerMap)
            //                                        .TrimEnd('\n').Replace("\n", "<br/>");
            // Patient Alert
            // patientAlertMap.TryGetValue(patDomain.PatId, out List<string> patientAlert);
            // patientAlert = patientAlert ?? new List<string>();

            // patientDto.Note = String.Join("<br/>", patientAlert.Select(x => "&nbsp;-&nbsp;" + x).ToArray());
            if (!String.IsNullOrEmpty(patientDto.Note))
            {
               patientDto.Note = "<b>Patient Alerts</b>: <br/>" + patientDto.Note;
               patientDto.HasImportantNote = true;
            }
            // if (!patientDto.Note.Equals("")) { patientDto.Note += "<br/>"; }
            // patientDto.Note += patientNote;
            #endregion

            patientDto.PracticeId = Config.Manager.PRACTICE_ID;
            // patientDto.Active = ConversionUtils.Patient.Status(patDomain.Status);
            patientDto.Carrier = 0;

            long feeScheduleId = Config.Map.s_feeScheduleMap.GetValue(patDomain.FeeSchedule);
            patientDto.FeeScheduledNumber = feeScheduleId != 0
               ? feeScheduleId
               : Config.Map.s_feeScheduleMap.GetValue(Config.Manager.DEFAULT_PATIENT_FEESCHEDULE);


            patientDto.OtherName = patDomain.PrefName;
            // patientDto.PatientType = ConversionUtils.Patient.PatientType(patDomain.Status);

            patientDto.PriStandardLifetime = TypesUtils.Parse.ToDouble(patDomain.PrStdDedLT);
            patientDto.PriPreventiveLifetime = TypesUtils.Parse.ToDouble(patDomain.PrPrvDedLT);
            patientDto.PriOtherLifetime = TypesUtils.Parse.ToDouble(patDomain.PrOthDedLT);
            patientDto.PriStandardIndividual = TypesUtils.Parse.ToDouble(patDomain.PrStdDed);
            patientDto.PriPreventiveIndividual = TypesUtils.Parse.ToDouble(patDomain.PrPrvDed);
            patientDto.PriOtherIndividual = TypesUtils.Parse.ToDouble(patDomain.PrOthDed);
            patientDto.PriUsedCoverageIndividual = TypesUtils.Parse.ToDouble(patDomain.PrBenefits);

            patientDto.SecStandardLifetime = TypesUtils.Parse.ToDouble(patDomain.SecStdDedLT);
            patientDto.SecPreventiveLifetime = TypesUtils.Parse.ToDouble(patDomain.SecPrvDedLT);
            patientDto.SecOtherLifetime = TypesUtils.Parse.ToDouble(patDomain.SecOthDedLT);
            patientDto.SecStandardIndividual = TypesUtils.Parse.ToDouble(patDomain.ScStdDed);
            patientDto.SecPreventiveIndividual = TypesUtils.Parse.ToDouble(patDomain.ScPrvDed);
            patientDto.SecOtherIndividual = TypesUtils.Parse.ToDouble(patDomain.ScOthDed);
            patientDto.SecUsedCoverageIndividual = TypesUtils.Parse.ToDouble(patDomain.ScBenefits);

            // default value
            patientDto.PracticeId = Config.Manager.PRACTICE_ID;
            /*
               patientDto.DataComplete = ISS.PATIENT.DEFAULT_DATA_COMPLETE;
               patientDto.StudentStatus = ISS.PATIENT.DEFAULT_STUDENT_STATUS;
               patientDto.SchoolName = ISS.PATIENT.DEFAULT_SCHOOL_NAME;
               patientDto.PriInsType = ISS.PATIENT.DEFAULT_INS_TYPE;
               patientDto.SecInsType = ISS.PATIENT.DEFAULT_INS_TYPE;
               patientDto.UserType = ISS.USER.DEFAULT_USER_TYPE_PATIENT;
            */
            // language. Todo: ressearch where store langue in EzDent
            if (patDomain.Language.Equals("0"))
            {
               var langDto = listLanguageDto.FirstOrDefault(x => x.Name == "English");
               if (langDto != null)
               {
                  patientDto.LanguageID = langDto.LanguageId;
               }
            }
            else if (patDomain.Language.Equals("2"))
            {
               var langDto = listLanguageDto.FirstOrDefault(x => x.Name == "Spanish");
               if (langDto != null)
               {
                  patientDto.LanguageID = langDto.LanguageId;
               }
            }

            var newUserId = TypesUtils.Parse.ToInt32(PatientDao.insert(patientDto));

            /*
             * var user = new Hashtable
            {
               {DATABASE.PATIENT.USER_ID, newUserId}
            };
            */
            //Config.Map.s_patientMap[patDomain.PatId] = user;
            if (!string.IsNullOrEmpty(patDomain.ChartNum))
            {
               Config.Map.s_patientChartMap[patDomain.ChartNum] = newUserId;
            }

            // Patient Referrer Map
            /*
            if (!patDomain.RefId.Equals("") && !patDomain.RefId.Equals("0"))
               if (!s_patientReferrerMap.ContainsKey(patDomain.RefId))
                  s_patientReferrerMap[patDomain.RefId] = newUserId;
            */
            Logger.log(count, total, $"Insert Patient {patientDto.PatientId} ({patientDto.FirstName} {patientDto.LastName}) - Chart#: {patDomain.ChartNum}");
         }

         #region Migrate Family

         count = 0;
         foreach (var domain in PatientList)
         {
            var hohMap = Config.Map.s_patientMap.GetValue(domain.FamilyId);
            if (hohMap == null)
            {
               Logger.error("[" + count + "/" + total + "]. [Patient: " + domain.PatId + "] No HOH with patient id [ " +
                            domain.FamilyId + " ] found.");
               continue;
            }

            //var hohId = TypesUtils.Parse.ToInt32(hohMap[DATABASE.USERS.USER_ID]);
            count++;

            var patientMap = Config.Map.s_patientMap.GetValue(domain.PatId);
            //var patientId = TypesUtils.Parse.ToInt32(patientMap[DATABASE.USERS.USER_ID]);
            /*
            if (patientId == 0)
            {
               Logger.error("[" + count + "/" + total + "]. [Patient: " + domain.PatId + "] No patient this id found.");
               continue;
            }
            */
            //update hoh
            //PatientDao.updateHeadOfHouseHold(patientId, hohId);
            Logger.log("[" + count + "/" + total + "]. [Patient: " + domain.PatId +
                       "] Update patient HoH, family ID: " + domain.FamilyId);
         }

         #endregion
      }

      public static void UpdatePatientProvider()
      {
         var allPatients = PatientDao.getPatientsFromAllPractices();
         var providerMap = StaffPracticeDao.getProviderDisplayIDMap();

         int count = 0, total = allPatients.Count;
         var providerId = TypesUtils.Parse.ToInt32(providerMap[Config.Manager.DEFAULT_TREATING_PROVIDER]);

         foreach (var dto in allPatients)
         {
            count++;
            PatientDao.updateTendingProvider(dto.UserId, providerId);
            Logger.log("[" + count + "/" + total + "]. Update tending provider for patient: " + dto.FirstName + " " +
                       dto.LastName);
         }

      }

      //update patient office phone and mobile phone
      public static void UpdatePatientPhone()
      {
         var allPatients = PatientDao.getPatientsFromAllPractices();

         int count = 0, total = allPatients.Count;
         foreach (var dto in allPatients)
         {
            count++;
            if (dto.PatientKey != null)
            {
               var domain = (from n in PatientList
                             where n.PatId.Equals(dto.PatientKey)
                             select n).FirstOrDefault();
               if (domain != null)
               {
                  dto.OfficePhone = FormatUtils.formatPhone(domain.WorkPhone);
                  dto.MobilePhone = FormatUtils.formatPhone(domain.Pager);
                  PatientDao.updateOfficePhone(dto.UserId, dto.OfficePhone);
                  PatientDao.updateMobilePhone(dto.UserId, dto.MobilePhone);
                  Logger.log("[" + count + "/" + total + "]. Update office phone & mobile phone for patient: " +
                             dto.FirstName + " " + dto.LastName +
                             " (PatID: " + dto.PatientId + ")");
               }
            }
         }

      }

      public static void DeletePatient()
      {
         PatientDao.deleteAllPatient();
      }
   }
}