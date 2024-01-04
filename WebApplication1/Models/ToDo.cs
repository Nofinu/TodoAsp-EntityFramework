using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ToDo
    {
   
        public int Id { get; set; }
        [Display(Name = "Titre")]
        public String Title { get; set; }
        [Display(Name = "Description")]
        public String Description { get; set; }
        [Display(Name = "Status")]
        public bool Finished { get; set; }

        public ToDo(int id, string title, string description, bool status)
        {
            Id = id;
            Title = title;
            Description = description;
            Finished = status;
        }

        public ToDo(string title, string description, bool status)
        {
            Title = title;
            Description = description;
            Finished = status;
        }

        public ToDo( string title, string description)
        {
            Title = title;
            Description = description;
        }
        public ToDo()
        {
        }
    }
}
