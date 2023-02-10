namespace Bookify.Web.Core.Models
{
    public class Category
    {
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        //لو عاوز احط التاريخ بنفس الوقت
        //public DateTime CreatedOn { get; set; } = DateTime.Now
        //public Category()
        //{
        //    CreatedOn = DateTime.Now;
        //}
        public DateTime? LastUpdatedOn { get; set; }

    }
}
