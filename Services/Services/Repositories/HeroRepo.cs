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
        private readonly HeroValidator _validator;

        public HeroRepo(HeroValidator validator)
        {
            _validator = validator;
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                SqlCommand cmd = new($"Delete from HPCharacters.dbo.Heroes where Heroes.ID = {id}", connection);
                connection.Open();
                await cmd.ExecuteNonQueryAsync();
                connection.Close();
                return str1;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<IEnumerable<Hero>> Get()
        {
            StringBuilder sb = new("select Heroes.ID, [First Name], [Second Name], [Dumbledore's Army], Faculties.Faculty ");
            sb.Append("from HPCharacters.dbo.Heroes ");
            sb.Append("inner join HPCharacters.dbo.Faculties on Heroes.Faculty = Faculties.ID");
            SqlDataAdapter da = new(sb.ToString(), connection);

            DataTable dt = new();
            var reader = await connection.CreateCommand().ExecuteReaderAsync();
            dt.Load(reader);

            List<Hero> heroes = new();
            if (dt.Rows.Count > 0)
            {
                heroes = dt.Rows.Cast<DataRow>()
                    .Select(x => new Hero()
                    {
                        ID = x.Field<int>("ID"),
                        FirstName = x.Field<string>("First Name"),
                        SecondName = x.Field<string>("Second Name"),
                        Fac = x.Field<int>("Faculty"),
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
            StringBuilder sb = new("select top 1 Heroes.ID, [First Name], [Second Name], [Dumbledore's Army], Faculties.Faculty ");
            sb.Append("from HPCharacters.dbo.Heroes ");
            sb.Append("inner join HPCharacters.dbo.Faculties on Heroes.Faculty = Faculties.ID ");
            sb.Append($"where Heroes.ID = {id}");
            SqlDataAdapter da = new(sb.ToString(), connection);
            DataTable dt = new();

            var reader = await connection.CreateCommand().ExecuteReaderAsync();
            dt.Load(reader);

            List<Hero> heroes = new();

            if (dt.Rows.Count > 0)
            {
                heroes = dt.Rows
                    .Cast<DataRow>()
                    .Select(x => new Hero()
                    {
                        ID = x.Field<int>("ID"),
                        FirstName = x.Field<string>("First Name"),
                        SecondName = x.Field<string>("Second Name"),
                        Fac = x.Field<int>("Faculty"),
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
            try
            {
                if (_validator.Validate(hero).IsValid is true)
                {
                    StringBuilder sb = new($"insert into HPCharacters.dbo.Heroes values ('{hero.ID}', '{hero.FirstName}', ");
                    sb.Append($"'{hero.SecondName}', '{hero.Fac}','{hero.Army}')");
                    SqlCommand cmd = new(sb.ToString());
                    connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                    connection.Close();
                    return str1;
                }
                else return str2;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string> Put(Hero hero)
        {
            if (_validator.Validate(hero).IsValid is true)
            {
                try
                {
                    StringBuilder sb = new($"Update HPCharacters.dbo.Heroes set [First Name] = '{hero.FirstName}', ");
                    sb.Append($"[Second Name] = '{hero.SecondName}', [Faculty] = {hero.Fac}, [Army] = {hero.Army}");
                    sb.Append($"where Heroes.ID = {hero.ID}");
                    SqlCommand cmd = new(sb.ToString(), connection);
                    connection.Open();
                    await cmd.ExecuteNonQueryAsync();
                    connection.Close();
                    return str1;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else
            {
                return str2;
            }
        }
    }
}
