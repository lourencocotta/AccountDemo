using AccountDemo.Dto;
using AccountDemo.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AccountDemo.MappingProfile
{
    public class TransactionProfile:Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionAddDto, Transaction>();
        }
    }
}
