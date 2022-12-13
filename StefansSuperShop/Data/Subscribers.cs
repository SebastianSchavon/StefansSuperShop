using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefansSuperShop.Data;

public class Subscribers
{
    [Key]
    [Column("SubscriberID")]
    public int SubscriberId { get; set; }
}