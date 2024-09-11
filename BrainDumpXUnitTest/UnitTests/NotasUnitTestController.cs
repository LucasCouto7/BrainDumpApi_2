using AutoMapper;
using BrainDumpApi_2.Context;
using BrainDumpApi_2.DTOs.Mappings;
using BrainDumpApi_2.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainDumpXUnitTest.UnitTests
{
    public class NotasUnitTestController
    {
        public readonly IUnitOfWork _repository;
        public readonly IMapper _mapper;
        private static readonly DbContextOptions<BrainDumpApiContext> _dbContextOptions;
        private const string _connectionString = "Server=NB-FNT-09;Database=BrainDumpApi;User Id=sa;Password=Lago287*;Trusted_Connection=True;TrustServerCertificate=True";

        static NotasUnitTestController()
        {
            _dbContextOptions = new DbContextOptionsBuilder<BrainDumpApiContext>()
                .UseSqlServer(_connectionString)
                .Options;
        }

        public NotasUnitTestController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new NotaDTOMappingProfile());
            });

            _mapper = config.CreateMapper();

            var context = new BrainDumpApiContext(_dbContextOptions);
            _repository = new UnitOfWork(context);
        }
    }

}
