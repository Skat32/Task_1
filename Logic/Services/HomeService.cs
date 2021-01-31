using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer;
using Logic.Exceptions;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.ViewModels;

namespace Logic.Services
{
    public class HomeService : IHomeService
    {
        private readonly HomeContext _context;
        private readonly IMapper _mapper;

        public HomeService(HomeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task SaveUserDataAsync(HomeViewModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x =>
                x.Email == model.Email || x.Phone == model.Phone);

            if (user != null)
                throw new AlreadyCreatedException("Пользователь с введенными данными уже существует", user.Id);

            await _context.Users.AddAsync(_mapper.Map<User>(model));

            await _context.SaveChangesAsync();
        }
    }
}