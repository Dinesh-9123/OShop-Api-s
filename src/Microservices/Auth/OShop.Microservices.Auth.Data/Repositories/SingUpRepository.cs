using MongoDB.Bson;
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
    public class SingUpRepository : ISingUpRepository
    {
        private readonly IMongoCollection<SignUpDto> _auth;
        private readonly IDatabaseFactory _databaseFactory;
        public SingUpRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _auth = _databaseFactory.GetDatabase().GetCollection<SignUpDto>("Auth");
        }

        public async Task<SignUpResponseDto> GetByEmailAsync(string email)
        {
            var filter = Builders<SignUpDto>.Filter.Eq("email", email); 
            var data = _auth.Find<SignUpDto>(filter).FirstOrDefault();
            if(data == null)
            {
                return new SignUpResponseDto
                {
                    isEmail = false,
                    isMobileNo = false,
                    result = false
                };
            }
             else if (data.email != null || data.email != "")
            {
                return new SignUpResponseDto
                {
                    isEmail = true,
                    isMobileNo = false,
                    result = false
                };
            }
            else
            {
                return new SignUpResponseDto
                {
                    isEmail = false,
                    isMobileNo = false,
                    result = false
                };
            }
        }

        public async Task<SignUpResponseDto> GetByPhoneNumberAsync(string phoneNumber)
        {
            var filter = Builders<SignUpDto>.Filter.Eq("mobileNo", phoneNumber);
            var data =  _auth.Find(filter).FirstOrDefault();
            if (data == null)
            {
                return new SignUpResponseDto
                {
                    isEmail = false,
                    isMobileNo = false,
                    result = false
                };
            }
            if (data.mobileNo != null || data.mobileNo != "")
            {
                return new SignUpResponseDto
                {
                    isEmail = true,
                    isMobileNo = true,
                    result = false
                };
            }
            else
            {
                return new SignUpResponseDto
                {
                    isEmail = false,
                    isMobileNo = false,
                    result = false
                };
            }
        }

        public async Task<SignUpResponseDto> SignUpAsync(SignUpDto signUpDto)
        {
            await _auth.InsertOneAsync(signUpDto);
            return new SignUpResponseDto
            {
                isEmail = true,
                isMobileNo = true,
                result = true
            };
        }
    }
}
