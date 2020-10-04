using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VibrantVoluntaire2.Models
{
    public class NGOAcc
    {
        [Key]
        public int NGOId { get; set; }
        [Required]
        [DisplayName ("What is the NGO name?")]
        public string NGOname { get; set; }
        [Required]
        public string vision { get; set; }
        [Required]
        public string mission { get; set; }
        [Required]
        public string objective { get; set; }
        [Required]
        public string HQlocation { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public string websiteaddress { get; set; }
        [Required]
        public string emailaddress { get; set; }
        [Required]
        public string establisheddate { get; set; }
        [Required]
        public string SMlink { get; set; }

        public NGOAcc()
        {
            NGOId = -1;
            NGOname = "";
            vision = "";
            mission = "";
            objective = "";
            HQlocation = "";
            status = "";
            websiteaddress = "";
            emailaddress = "";
            establisheddate = "";
            SMlink = "";
        }

        public NGOAcc(int nGOId, string nGOname, string vision, string mission, string objective, string hQlocation, string status, string websiteaddress, string emailaddress, string establisheddate, string sMlink)
        {
            NGOId = nGOId;
            NGOname = nGOname;
            this.vision = vision;
            this.mission = mission;
            this.objective = objective;
            HQlocation = hQlocation;
            this.status = status;
            this.websiteaddress = websiteaddress;
            this.emailaddress = emailaddress;
            this.establisheddate = establisheddate;
            SMlink = sMlink;
        }
    }


}