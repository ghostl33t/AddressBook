﻿using AddressBook.Domain;
using AddressBook.Domain.Models;
using AddressBook.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Repositories.ContactRepository;
public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public ContactRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<List<ContactGetDTO>> GetAllContactsAsync()
    {
        var contacts = await _dbContext.Contacts.Include(x => x.City).Include(x => x.City.Country).ToListAsync();

        return _mapper.Map<List<ContactGetDTO>>(contacts);
    }
    public async Task<bool> CreateNewContactAsync(Contact newContact)
    {
        try
        {
            _dbContext.Contacts.Add(newContact);
            await _dbContext.SaveChangesAsync();
            return await Task.FromResult(true);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Exception occured: {ex.ToString()}");
            throw;
        }
        
    }
}
