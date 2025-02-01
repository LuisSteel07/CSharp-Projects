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
            string TaskTableQuery = "CREATE TABLE IF NOT EXISTS tasks (id INTEGER PRIMARY KEY, title TEXT, description TEXT, category TEXT, owner INTEGER)";
            using (SQLiteCommand command = new SQLiteCommand(TaskTableQuery, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Tabla creada.\n");
            }
            connection.Close();
        }
    }

    public void Execute(string query){
        using (SQLiteConnection connection = new SQLiteConnection(db)){
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(query, connection)){
                command.ExecuteNonQuery();
                Console.WriteLine("Consulta realizado con exito. \n");
            }
            connection.Close();
        }
    }

    public void ListData(){
        using (SQLiteConnection connection = new SQLiteConnection(db))
        {
            connection.Open();
            string sql = "SELECT * FROM tasks";
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["id"]}\nTitle: {reader["title"]}\nDescription: {reader["description"]}\nCategory: {reader["category"]}\n");
                    }
                }
            }
            connection.Close();
        }
    }

    public bool CheckID(int id){
        using (SQLiteConnection connection = new SQLiteConnection(db))
        {
            int max = 0, min = 0;
            connection.Open();
            string sql = "SELECT MAX(id) as max_id, MIN(id) as min_id FROM tasks";
            using (SQLiteCommand command = new SQLiteCommand(sql, connection)){
                using (SQLiteDataReader reader = command.ExecuteReader()){
                    while (reader.Read()){
                        max = int.Parse($"{reader["max_id"]}");
                        min = int.Parse($"{reader["min_id"]}");
                    }
                }
            }
            connection.Close();
            Console.WriteLine($"MAX {max} MIN {min}");
            if(id < min || id > max) return true;
            else return false;
        }
    }
}