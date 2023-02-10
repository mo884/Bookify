namespace Bookify.Web.Core.ViewModel
{
    public class CategoryView
    {
        public int ID { get; set; }
        [MaxLength(20,ErrorMessage ="Max Length can not more 20")]
        public string Name { get; set; } = null!;
    }
}
