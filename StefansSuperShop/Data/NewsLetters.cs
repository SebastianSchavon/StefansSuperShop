using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefansSuperShop.Data;

public class NewsLetters
{
    [Key]
    [Column("NewsLetterID")]
    public int NewsLetterId { get; set; }
}