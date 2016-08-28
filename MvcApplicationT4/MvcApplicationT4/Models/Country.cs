using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace MvcApplicationT4.Models
{
    [DisplayColumn("name")]
    public partial class Country
    {
        public string name { get; set; }
        public string dsc { get; set; }
        public int  dateBuild { get; set; }

        public int selectedDate { get; set;  }
    }

    [MetadataType(typeof(CountryMetadata))]
    public partial class Country
    {

        
    }

    public class CountryMetadata
    {
      //  [HiddenInput(DisplayValue= false)]
        [Display(Name = "Description !!! :")]       
        public string dsc { get; set; }

        [Display(Name = "Counytry name")]
        [DisplayFormat(NullDisplayText = "No Name")]
        //[System.ComponentModel.ReadOnlyAttribute(true)]        
        public string name { get; set; }

         [Display(Name = "Date founded")]
        [DisplayFormat(NullDisplayText="0000 bc")]
        public int dateBuild { get; set; }

        [HiddenInput(DisplayValue = false)]
         public int selectedDate { get; set; }
    }
}