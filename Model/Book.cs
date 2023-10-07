using System.ComponentModel.DataAnnotations;

namespace BookListRazor.Model
{
    public class Book
    {
        [Key]// add ID as an identity, create ID Value automatically
        public int Id { get; set; }
        
        [Required]//name cannot be null
        public string Name { get; set; }
        public string Author { get; set; }

        public string ISBN{ get; set; }

    }
}
