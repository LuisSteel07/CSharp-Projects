using System.Data.SQLite;

class ORM{
    private string db;

    public ORM(string _db){
        db = _db;
    }

    public void InitDB(){
        using (SQLiteConnection connection = new SQLiteConnection(db))
        {
            connection.Open();

            string UserTableQuery = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY, name TEXT, password TEXT)";
            using (SQLiteCommand command = new SQLiteCommand(UserTableQuery, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Tabla creada.");
            }

            string TaskTableQuery = "CREATE TABLE IF NOT EXISTS tasks (id INTEGER PRIMARY KEY, title TEXT, description TEXT, category TEXT, owner INTEGER)";
            using (SQLiteCommand command = new SQLiteCommand(TaskTableQuery, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Tabla creada.");
            }

            connection.Close();
        }
    }

    public void Execute(string query){
        using (SQLiteConnection connection = new SQLiteConnection(db)){
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(query, connection)){
                command.ExecuteNonQuery();
                Console.WriteLine("Consulta realizado con exito.");
            }
            connection.Close();
        }
    }
}