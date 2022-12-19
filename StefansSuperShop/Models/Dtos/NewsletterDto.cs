using System.Collections.Generic;
using StefansSuperShop.Data;

namespace StefansSuperShop.Models.Dtos;

public class NewsletterDto
{
    public int NewsletterId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public bool NewsletterSent { get; set; }
    public List<Subscriber> SubscribersWhoReceivedNewsletter { get; set; }
}