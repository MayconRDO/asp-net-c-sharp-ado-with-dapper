using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = "User Id=sa;Password=devsa;Initial Catalog=Blog;Data Source=(local);Integrated Security=SSPI;Connect Timeout=45";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            //ReadUsers(connection);
            //ReadRoles(connection);
            //ReadTags(connection);
            //ReadUser(connection);
            //CreateUser(connection);
            //UpdateUser(connection);
            //DeleteUser(connection);
            //ReadRoles(connection);
            ReadUsersWithRoles(connection);

            connection.Close();
        }

        #region Users
        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                { 
                    Console.WriteLine($" - {role.Name}");
                }
            }
        }        

        public static void ReadUser(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var item = repository.Get(1);
            Console.WriteLine(item.Name);
        }

        public static void CreateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Bio = "Equipe CC.io",
                Email = "cc@balta.io",
                Image = "cc://",
                Name = "cc.io",
                PasswordHash = "HASH",
                Slug = "equipe-cc"
            };

            var repository = new Repository<User>(connection);
            repository.Create(user);
            Console.WriteLine("Cadastro realizado com sucesso!");

        }

        public static void UpdateUser(SqlConnection connection)
        {
            var user = new User()
            {
                Id = 2,
                Bio = "Equipe | balta.io",
                Email = "hello@balta.io",
                Image = "https://",
                Name = "Equipe de suporte balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            var repository = new Repository<User>(connection);
            repository.Update(user);
            Console.WriteLine("Atualização realizada com sucesso!");

        }

        public static void DeleteUser(SqlConnection connection)
        {
            var user = new User()
            {
                Id = 2,
                Bio = "Equipe | balta.io",
                Email = "hello@balta.io",
                Image = "https://",
                Name = "Equipe de suporte balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            var repository = new Repository<User>(connection);
            repository.Delete(user);
            Console.WriteLine("Exclusão realizada com sucesso!");
        }
        #endregion

        #region Roles
        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
        }
        #endregion

        #region Users with Roles
        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                { 
                    Console.WriteLine($" - {role.Name}");
                }
            }
        }
        #endregion

        #region Tags
        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
        }
        #endregion
    }
}