using LoginSystem.Data;
using LoginSystem.Models;
using Microsoft.Data.SqlClient;

namespace LoginSystem.Repositories
{
    public class UserRepository
    {
        private readonly Database _database;

        public UserRepository(Database database)
        {
            _database = database;
        }

        // =========================
        // 1. VERIFICAR EMAIL
        // =========================
        public bool EmailExists(string email)
        {
            using SqlConnection connection = _database.GetConnection();
            connection.Open();

            string sql = @"
                SELECT COUNT(*)
                FROM Users
                WHERE Email = @Email";

            using SqlCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@Email", email);

            int count = (int)command.ExecuteScalar();

            return count > 0;
        }

        // =========================
        // 2. INSERIR USUÁRIO (CADASTRO)
        // =========================
        public void Insert(User user)
        {
            using SqlConnection connection = _database.GetConnection();
            connection.Open();

            string sql = @"
                INSERT INTO Users (Name, Email, PasswordHash, CreatedAt)
                VALUES (@Name, @Email, @PasswordHash, @CreatedAt)";

            using SqlCommand command = new(sql, connection);

            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            command.Parameters.AddWithValue("@CreatedAt", user.CreatedAt);

            command.ExecuteNonQuery();
        }

        // =========================
        // 3. BUSCAR POR EMAIL (LOGIN)
        // =========================
        public User? GetByEmail(string email)
        {
            using SqlConnection connection = _database.GetConnection();
            connection.Open();

            string sql = @"
                SELECT Id, Name, Email, PasswordHash, CreatedAt
                FROM Users
                WHERE Email = @Email";

            using SqlCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@Email", email);

            using SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return new User
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString() ?? "",
                Email = reader["Email"].ToString() ?? "",
                PasswordHash = reader["PasswordHash"].ToString() ?? "",
                CreatedAt = (DateTime)reader["CreatedAt"]
            };
        }

        // =========================
        // 4. BUSCAR POR ID (opcional, mas recomendado)
        // =========================
        public User? GetById(int id)
        {
            using SqlConnection connection = _database.GetConnection();
            connection.Open();

            string sql = @"
                SELECT Id, Name, Email, PasswordHash, CreatedAt
                FROM Users
                WHERE Id = @Id";

            using SqlCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@Id", id);

            using SqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return new User
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString() ?? "",
                Email = reader["Email"].ToString() ?? "",
                PasswordHash = reader["PasswordHash"].ToString() ?? "",
                CreatedAt = (DateTime)reader["CreatedAt"]
            };
        }
    }
}