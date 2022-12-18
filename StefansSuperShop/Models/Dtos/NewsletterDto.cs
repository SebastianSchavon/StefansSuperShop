using System.Collections.Generic;
using StefansSuperShop.Data;

namespace StefansSuperShop.Models.Dtos;

public class NewsletterDto
{
    public string Content { get; set; }
    public bool NewsletterSent { get; set; }
    public List<Subscribers> SubscribersWhoReceivedNewsletter { get; set; }
}