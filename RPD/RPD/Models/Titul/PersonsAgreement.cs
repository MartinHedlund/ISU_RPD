using RPD.Models.BD_model;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;

namespace RPD.Models.Titul
{
    public class PersonsAgreement
    {
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? PName { get; set; }
        public int IdPerson { get; set; }
        public string? FIO { get {return LName +" "+FName + " " + PName;}}
        public string? FioSokr { get { return FName[0] +"."+PName[0]+". "+ LName;} }
        public string? FioSokrForDocx { get { return LName+" "+FName[0] +"."+PName[0]+".";} }
        public string? UchStepen { get; set; }
        public string? UchZvanie { get; set; }
      
        public int Type { get; set; }
        public DateTime? DateApproval { get; set; }
        public string? NumberProtocol { get; set; }

        public string? NameInstKaf { get; set; }
        public string? NameInstKafSokr { get; set; }
        public int IdDepart { get; set; }
     
        public PersonsAgreement(PersonModel Pers, DepartmentModel Dep, int Type)
        {
            this.IdPerson = Pers.IdPerson;
            this.LName = Pers.LName;
            this.FName = Pers.FName;
            this.PName = Pers.PName;
            this.UchStepen = Pers.UchStepen;
            this.UchZvanie = Pers.UchZvanie;
            this.NameInstKaf = Dep.NDepartment;
            this.NameInstKafSokr = Dep.DepartmentSokr;
            this.IdDepart = Dep.IdDepartment;
            this.Type = Type;
        }
        public PersonsAgreement(PersonAgreementModel personAgreementModel, DepartmentModel Depart, PersonModel person)
        {
            this.FName = person.FName;
            this.LName = person.LName;
            this.PName = person.PName;
            this.IdPerson = person.IdPerson;
            this.UchStepen = person.UchStepen;
            this.UchZvanie = person.UchZvanie;

            this.Type = personAgreementModel.Type;
            this.DateApproval = personAgreementModel.DateAgree;
            this.NumberProtocol = personAgreementModel.NumberAgree;

            this.NameInstKaf = Depart.NDepartment;
            this.NameInstKafSokr = Depart.DepartmentSokr;
            this.IdDepart = Depart.IdDepartment;
        }
    }
}
