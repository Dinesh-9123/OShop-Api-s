using MongoDB.Driver;
using OShop.Microservices.Auth.DataInterfaces;
using OShop.Microservices.Auth.Doman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OShop.Microservices.Auth.Data.Repositories
{
    public class SingInRepository : ISingInRepository
    {
        private readonly IMongoCollection<SignUpDto> _auth;
        private readonly IDatabaseFactory _databaseFactory;
        public SingInRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _auth = (_databaseFactory.GetDatabase()).GetCollection<SignUpDto>("Auth");
        }

        public async Task<string> GetDatabase()
        {
            var result = await _auth.FindAsync(student => true);
            return "success";
        }

        public async Task<SignInDto> SignInAsync(SignInDto signInDto)
        {
            var result = await GetByEmailAsync(signInDto.email);
            if(result.password.Equals(signInDto.password))
            {
                return new SignInDto
                {
                    email = result.email,
                    password = result.password,
                    userId = result.userId,
                    status = result.status,
                    mobileNo = result.mobileNo,
                    role = result.role,
                };
            }
            else
            {
                throw new Exception("Invalid password");
            }
           
        }
        private async Task<SignUpDto> GetByEmailAsync(string email)
        {
            var filter = Builders<SignUpDto>.Filter.Eq("email", email);
            var data = _auth.Find<SignUpDto>(filter).FirstOrDefault();
            if(data == null)
            {
                throw new Exception("email not exist");
            }
            else
            {
                return data;
            }
        }
    }
}
