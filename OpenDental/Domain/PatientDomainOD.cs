using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Domain
{
   public class PatientDomain
   {
      public PatientDomain(DataRow dataRow)
      {
         PatId = dataRow.GetValueDefault("PatNum", "").Trim();
         FamilyId = dataRow.GetValueDefault("FamilyId", "").Trim();
         LastName = dataRow.GetValueDefault("LName", "").Trim();
         FirstName = dataRow.GetValueDefault("FName", "").Trim();
         MI = dataRow.GetValueDefault("MI", "").Trim();
         PrefName = dataRow.GetValueDefault("PrefName", "").Trim();
         Salutation = dataRow.GetValueDefault("Salutation", "").Trim();
         WkExt = dataRow.GetValueDefault("WkExt", "").Trim();
         BestTime = dataRow.GetValueDefault("BestTime", "").Trim();
         ChartNum = dataRow.GetValueDefault("ChartNumber", "").Trim();
         SSN = dataRow.GetValueDefault("SSN", "").Trim();
         ProvId1 = dataRow.GetValueDefault("ProvId1", "").Trim();
         ProvId2 = dataRow.GetValueDefault("ProvId2", "").Trim();
         IsGuarantor = dataRow.GetValueDefault("IsGuarantor", "").Trim();
         IsInsSubcriber = dataRow.GetValueDefault("IsInsSubcriber", "").Trim();
         IsHeadOfHouse = dataRow.GetValueDefault("IsHeadOfHouse", "").Trim();
         Gender = dataRow.GetValueDefault("Gender", "").Trim();
         Status = dataRow.GetValueDefault("Status", "").Trim();
         FamPos = dataRow.GetValueDefault("FamPos", "").Trim();
         PrInsCDADepCode = dataRow.GetValueDefault("PrInsCDADepCode", "").Trim();
         ScInsCDADepCode = dataRow.GetValueDefault("ScInsCDADepCode", "").Trim();
         PreMed = dataRow.GetValueDefault("PreMed", "").Trim();
         AddressId = dataRow.GetValueDefault("Address", "").Trim();
         BirthDate = dataRow.GetValueDefault("BirthDate", "").Trim();
         EmpId = dataRow.GetValueDefault("EmpId", "").Trim();
         GuarId = dataRow.GetValueDefault("GuarId", "").Trim();
         FirstVisit = dataRow.GetValueDefault("FirstVisit", "").Trim();
         LastVisit = dataRow.GetValueDefault("LastVisit", "").Trim();
         MedAlertMask1 = dataRow.GetValueDefault("MedAlertMask1", "").Trim();
         MedAlertMask2 = dataRow.GetValueDefault("MedAlertMask2", "").Trim();
         RefId = dataRow.GetValueDefault("RefId", "").Trim();
         RefById = dataRow.GetValueDefault("RefById", "").Trim();
         RefToId = dataRow.GetValueDefault("RefToId", "").Trim();
         RefToDate = dataRow.GetValueDefault("RefToDate", "").Trim();
         ConsentDate = dataRow.GetValueDefault("ConsentDate", "").Trim();
         PrInsRel = dataRow.GetValueDefault("PrInsRel", "").Trim();
         ScInsRel = dataRow.GetValueDefault("ScInsRel", "").Trim();
         PrInsuredId = dataRow.GetValueDefault("PrInsuredId", "").Trim();
         PrBenefits = dataRow.GetValueDefault("PrBenefits", "").Trim();
         ScInsuredId = dataRow.GetValueDefault("ScInsuredId", "").Trim();
         ScBenefits = dataRow.GetValueDefault("ScBenefits", "").Trim();
         ClaimInfId = dataRow.GetValueDefault("ClaimInfId", "").Trim();
         WorkPhone = dataRow.GetValueDefault("WkPhone", "").Trim();
         FeeSchType = dataRow.GetValueDefault("FeeSchType", "").Trim();
         FeeSchedule = dataRow.GetValueDefault("FeeSchedule", "").Trim();
         MissedAppt = dataRow.GetValueDefault("MissedAppt", "").Trim();
         LastMissedAppt = dataRow.GetValueDefault("LastMissedAppt", "").Trim();
         Title = dataRow.GetValueDefault("Title", "").Trim();
         Id2 = dataRow.GetValueDefault("Id2", "").Trim();
         TitleFlag = dataRow.GetValueDefault("TitleFlag", "").Trim();
         EZDWPatId = dataRow.GetValueDefault("EZDWPatId", "").Trim();
         PrMedInsRel = dataRow.GetValueDefault("PrMedInsRel", "").Trim();
         ScMedInsRel = dataRow.GetValueDefault("ScMedInsRel", "").Trim();
         PrMedInsuredId = dataRow.GetValueDefault("PrMedInsuredId", "").Trim();
         ScMedInsuredId = dataRow.GetValueDefault("ScMedInsuredId", "").Trim();
         Language = dataRow.GetValueDefault("Language", "").Trim();
         Email = dataRow.GetValueDefault("Email", "").Trim();
         DriversLicense = dataRow.GetValueDefault("DriversLicense", "").Trim();
         Fax = dataRow.GetValueDefault("Fax", "").Trim();
         Pager = dataRow.GetValueDefault("Pager", "").Trim();
         OtherPhone = dataRow.GetValueDefault("WirelessPhone", "").Trim();
         PrStdDed = dataRow.GetValueDefault("PrStdDed", "").Trim();
         PrPrvDed = dataRow.GetValueDefault("PrPrvDed", "").Trim();
         PrOthDed = dataRow.GetValueDefault("PrOthDed", "").Trim();
         ScStdDed = dataRow.GetValueDefault("ScStdDed", "").Trim();
         ScPrvDed = dataRow.GetValueDefault("ScPrvDed", "").Trim();
         ScOthDed = dataRow.GetValueDefault("ScOthDed", "").Trim();
         PrStdDedLT = dataRow.GetValueDefault("PrStdDedLT", "").Trim();
         PrPrvDedLT = dataRow.GetValueDefault("PrPrvDedLT", "").Trim();
         PrOthDedLT = dataRow.GetValueDefault("PrOthDedLT", "").Trim();
         SecStdDedLT = dataRow.GetValueDefault("SecStdDedLT", "").Trim();
         SecPrvDedLT = dataRow.GetValueDefault("SecPrvDedLT", "").Trim();
         SecOthDedLT = dataRow.GetValueDefault("SecOthDedLT", "").Trim();
         PrStdDedLastYr = dataRow.GetValueDefault("PrStdDedLastYr", "").Trim();
         PrPrvDedLastYr = dataRow.GetValueDefault("PrPrvDedLastYr", "").Trim();
         PrOthDedLastYr = dataRow.GetValueDefault("PrOthDedLastYr", "").Trim();
         ScStdDedLastYr = dataRow.GetValueDefault("ScStdDedLastYr", "").Trim();
         ScPrvDedLastYr = dataRow.GetValueDefault("ScPrvDedLastYr", "").Trim();
         ScOthDedLastYr = dataRow.GetValueDefault("ScOthDedLastYr", "").Trim();
         PrBenefitsLastYr = dataRow.GetValueDefault("PrBenefitsLastYr", "").Trim();
         ScBenefitsLastYr = dataRow.GetValueDefault("ScBenefitsLastYr", "").Trim();
         PatAlert = dataRow.GetValueDefault("PatAlert", "").Trim();
         PrivacyFlags = dataRow.GetValueDefault("PrivacyFlags", "").Trim();
         GuidId = dataRow.GetValueDefault("GuidId", "").Trim();
      }

      public PatientDomain() { }

      public string PatId { get; set; }
      public string FamilyId { get; set; }
      public string LastName { get; set; }
      public string FirstName { get; set; }
      public string MI { get; set; }
      public string PrefName { get; set; }
      public string Salutation { get; set; }
      public string WkExt { get; set; }
      public string BestTime { get; set; }
      public string ChartNum { get; set; }
      public string SSN { get; set; }
      public string ProvId1 { get; set; }
      public string ProvId2 { get; set; }
      public string IsGuarantor { get; set; }
      public string IsInsSubcriber { get; set; }
      public string IsHeadOfHouse { get; set; }
      public string Gender { get; set; }
      public string Status { get; set; }
      public string FamPos { get; set; }
      public string PrInsCDADepCode { get; set; }
      public string ScInsCDADepCode { get; set; }
      public string PreMed { get; set; }
      public string AddressId { get; set; }
      public string BirthDate { get; set; }
      public string EmpId { get; set; }
      public string GuarId { get; set; }
      public string FirstVisit { get; set; }
      public string LastVisit { get; set; }
      public string MedAlertMask1 { get; set; }
      public string MedAlertMask2 { get; set; }
      public string RefId { get; set; }
      public string RefById { get; set; }
      public string RefToId { get; set; }
      public string RefToDate { get; set; }
      public string ConsentDate { get; set; }
      public string PrInsRel { get; set; }
      public string ScInsRel { get; set; }
      public string PrInsuredId { get; set; }
      public string PrBenefits { get; set; }
      public string ScInsuredId { get; set; }
      public string ScBenefits { get; set; }
      public string ClaimInfId { get; set; }
      public string WorkPhone { get; set; }
      public string FeeSchType { get; set; }
      public string FeeSchedule { get; set; }
      public string MissedAppt { get; set; }
      public string LastMissedAppt { get; set; }
      public string Title { get; set; }
      public string Id2 { get; set; }
      public string TitleFlag { get; set; }
      public string EZDWPatId { get; set; }
      public string PrMedInsRel { get; set; }
      public string ScMedInsRel { get; set; }
      public string PrMedInsuredId { get; set; }
      public string ScMedInsuredId { get; set; }
      public string Language { get; set; }
      public string Email { get; set; }
      public string DriversLicense { get; set; }
      public string Fax { get; set; }
      public string Pager { get; set; }
      public string OtherPhone { get; set; }
      public string PrStdDed { get; set; }
      public string PrPrvDed { get; set; }
      public string PrOthDed { get; set; }
      public string ScStdDed { get; set; }
      public string ScPrvDed { get; set; }
      public string ScOthDed { get; set; }
      public string PrStdDedLT { get; set; }
      public string PrPrvDedLT { get; set; }
      public string PrOthDedLT { get; set; }
      public string SecStdDedLT { get; set; }
      public string SecPrvDedLT { get; set; }
      public string SecOthDedLT { get; set; }
      public string PrStdDedLastYr { get; set; }
      public string PrPrvDedLastYr { get; set; }
      public string PrOthDedLastYr { get; set; }
      public string ScStdDedLastYr { get; set; }
      public string ScPrvDedLastYr { get; set; }
      public string ScOthDedLastYr { get; set; }
      public string PrBenefitsLastYr { get; set; }
      public string ScBenefitsLastYr { get; set; }
      public string PatAlert { get; set; }
      public string PrivacyFlags { get; set; }
      public string GuidId { get; set; }
   }
}
