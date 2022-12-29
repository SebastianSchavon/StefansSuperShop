using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefansSuperShop.Data;

public class Newsletter
{
    [Key]
    [Column("NewsletterID")]
    public int NewsLetterId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool NewsletterSent { get; set; }
    public virtual List<Subscriber> SubscribersWhoReceivedNewsletter { get; set; }
}