using Newtonsoft.Json;
using Services.Models;
using Services.Validators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class HeroRepo : IAsyncRepository<Hero>
    {
        const string str1 = "Success!";
        const string str2 = "Something's wrong!";
        readonly SqlConnection connection = new(@"server=localhost\SQLEXPRESS; Database=HPCharacters; Trusted_Connection=True;");
        private readonly IHeroValidator _validator;

        public HeroRepo(IHeroValidator validator)
        {
            _validator = validator;
        }

        public async Task<string> Delete(int id)
        {
            StringBuilder sb = new($"Delete from HPCharacters.dbo.Heroes where Heroes.ID = {id}");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = sb.ToString();
            await command.ExecuteNonQueryAsync();
            connection.Close();
            return str1;
        }

        public async Task<IEnumerable<Hero>> Get()
        {
            StringBuilder sb = new("select * ");
            sb.Append(" from HPCharacters.dbo.Heroes ");
            using SqlDataAdapter da = new(sb.ToString(), connection);

            connection.Open();
            DataTable dt = new();
            var command = connection.CreateCommand();
            command.CommandText = sb.ToString();
            var reader = await command.ExecuteReaderAsync();
            dt.Load(reader);
            connection.Close();

            List<Hero> heroes = new();
            if (dt.Rows.Count > 0)
            {
                heroes = dt.Rows.Cast<DataRow>()
                    .Select(x => new Hero()
                    {
                        ID = x.Field<Int16>("ID"),
                        FirstName = x.Field<string>("First Name"),
                        SecondName = x.Field<string>("Second Name"),
                        Fac = x.Field<Int16>("Faculty"),
                        Army = x.Field<bool>("Dumbledore's Army")
                    }).ToList();
                return heroes;
            }
            else
            {
                return heroes;
            }
        }

        public async Task<Hero> GetById(int id)
        {
            StringBuilder sb = new("select * ");
            sb.Append(" from HPCharacters.dbo.Heroes ");
            sb.Append($"where Heroes.ID = {id}");
            SqlDataAdapter da = new(sb.ToString(), connection);
            DataTable dt = new();

            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = sb.ToString();
            var reader = await command.ExecuteReaderAsync();
            dt.Load(reader);
            connection.Close();

            List<Hero> heroes = new();

            if (dt.Rows.Count > 0)
            {
                heroes = dt.Rows
                    .Cast<DataRow>()
                    .Select(x => new Hero()
                    {
                        ID = x.Field<Int16>("ID"),
                        FirstName = x.Field<string>("First Name"),
                        SecondName = x.Field<string>("Second Name"),
                        Fac = x.Field<Int16>("Faculty"),
                        Army = x.Field<bool>("Dumbledore's Army")
                    }).ToList();
                return heroes[0];
            }
            else
            {
                return new Hero();
            }
        }

        public async Task<string> Post(Hero hero)
        {
            if (_validator.Validate(hero).IsValid)
            {
                StringBuilder sb = new($"insert into HPCharacters.dbo.Heroes values ('{hero.ID}', '{hero.FirstName}', ");
                sb.Append($"'{hero.SecondName}', '{hero.Fac}','{hero.Army}')");
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sb.ToString();
                await command.ExecuteNonQueryAsync();
                connection.Close();
                return str1;
            }
                else return str2;
        }

        public async Task<string> Put(Hero hero)
        {
            if (_validator.Validate(hero).IsValid)
            {
                StringBuilder sb = new($"Update HPCharacters.dbo.Heroes set [First Name] = '{hero.FirstName}', ");
                sb.Append($"[Second Name] = '{hero.SecondName}', [Faculty] = {hero.Fac}, [Army] = {hero.Army}");
                sb.Append($"where Heroes.ID = {hero.ID}");
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = sb.ToString();
                await command.ExecuteNonQueryAsync();
                connection.Close();
                return str1;
            }
            else
            {
                return str2;
            }
        }
    }
}
