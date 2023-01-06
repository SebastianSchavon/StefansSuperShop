using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefansSuperShop.Data;

public class Subscriber
{
    [Key] [Column("SubscriberID")] public int SubscriberId { get; set; }
    [Required] public string EmailAddress { get; set; }
    public virtual List<Newsletter> ReceivedNewsletters { get; set; }
}