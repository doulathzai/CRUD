using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Model
    {
        
        public int? Id { get; set; }
        [Required(ErrorMessage ="The value is required")]
        public int AmtSend { get; set; }
        [Required(ErrorMessage ="The value is required")]
        public decimal AmtRecieve { get; set; }
        [Required(ErrorMessage ="Senders name is required")]
        [StringLength(50)]
        public string SenderName { get; set; }
        [Required(ErrorMessage="Recievers name is required")]
        [StringLength (50)]
        public string RecieverName { get; set; }
        public string Purpose { get; set; }
        //[Required(ErrorMessage = "Please select a valid option.")]
        //[EnumDataType(typeof(DropdownOptions), ErrorMessage = "Invalid selection.")]
        //public DropdownOptions Purpose { get; set; }

        // other properties
    }

    //public enum DropdownOptions
    //{
    //    Scolarship,
    //    FeePayment,
    //    Zakaat,
    //    StockInvestment,
    //    SellingofCapital

    //}
}
