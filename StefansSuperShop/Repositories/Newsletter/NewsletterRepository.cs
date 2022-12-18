using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using StefansSuperShop.Data;
using StefansSuperShop.Helpers;
using StefansSuperShop.Models.Dtos;
using StefansSuperShop.Services.EmailSender;

namespace StefansSuperShop.Repositories.Newsletter;

public class NewsletterRepository : INewsletterRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IEmailSenderService _senderService;
    private readonly IMapper _mapper;

    public NewsletterRepository(ApplicationDbContext dbContext,  IEmailSenderService senderService, IMapper mapper)
    {
        _dbContext = dbContext;
        _senderService = senderService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Newsletters>> GetNewsletters()
    {
        return _dbContext.Newsletters;
    }
    
    
    // dont send email after creation, just add to database as "not sent" 
    public async Task CreateNewsletterAsync(NewsletterDto newsletterDto)
    {
        await _dbContext.Newsletters.AddAsync(_mapper.MapNewsletterDto(newsletterDto));
    }

    public async Task EditNewsletterAsync(string newsletterId)
    {
        
    }


    
}