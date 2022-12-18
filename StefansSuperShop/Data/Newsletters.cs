using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefansSuperShop.Data;

public class Newsletters
{
    [Key]
    [Column("NewsletterID")]
    public int NewsLetterId { get; set; }
    public string Content { get; set; }
    public bool NewsletterSent { get; set; }
    public List<Subscribers> SubscribersWhoReceivedNewsletter { get; set; }
}