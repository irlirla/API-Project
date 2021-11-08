using Newtonsoft.Json;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class HeroRepo : IRepository<Hero>
    {
        readonly SqlConnection connection = new(@"server=localhost\SQLEXPRESS; Database=HPCharacters; Trusted_Connection=True;");

        public void Delete(int id)
        {
            SqlCommand cmd = new($"Delete from HPCharacters.dbo.Heroes where Heroes.ID = {id}", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<Hero> Get()
        {
            SqlDataAdapter da = new("select Heroes.ID, [First Name], [Second Name], [Dumbledore's Army], Faculties.Faculty " +
                "from HPCharacters.dbo.Heroes " +
                "inner join HPCharacters.dbo.Faculties on Heroes.Faculty = Faculties.ID", connection);
            DataTable dt = new();
            da.Fill(dt);

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

        public Hero GetById(int id)
        {
            SqlDataAdapter da = new("select Heroes.ID, [First Name], [Second Name], [Dumbledore's Army], Faculties.Faculty " +
               "from HPCharacters.dbo.Heroes " +
               "inner join HPCharacters.dbo.Faculties on Heroes.Faculty = Faculties.ID " +
               $"where Heroes.ID = {id}", connection);
            DataTable dt = new();

            da.Fill(dt);
            Hero hero = new();

            //var lst = AsEnumerable(dt);
            if (dt.Rows.Count > 0)
            {
                hero = dt.Row.Select(x => new Hero()
                    {
                        ID = x.Field<int>("ID"),
                        FirstName = x.Field<string>("First Name"),
                        SecondName = x.Field<string>("Second Name"),
                        Fac = x.Field<int>("Faculty"),
                        Army = x.Field<bool>("Dumbledore's Army")});
                return hero;
            }
            else
            {
                return hero;
            }
        }

        public void Post(Hero hero)
        {
            try
            {
                SqlCommand cmd = new($"insert into HPCharacters.dbo.Heroes values ('{hero.ID}', '{hero.FirstName}', " +
                    $"'{hero.SecondName}', '{hero.Fac}','{hero.Army}')");
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                //return e.Message;
            }
        }

        public void Put(Hero hero)
        {
            SqlCommand cmd = new($"Update HPCharacters.dbo.Heroes set [First Name] = '{hero.FirstName}', " +
                $"[Second Name] = '{hero.SecondName}', [Faculty] = {hero.Fac}, [Army] = {hero.Army}" +
                $"where Heroes.ID = {hero.ID}", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
