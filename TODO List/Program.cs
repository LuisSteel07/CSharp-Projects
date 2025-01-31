class Program
{
    static ORM orm = new ORM("Data Source=db.db;Version=3;");
    
    static void LoginUser(){}

    static void SingUp(){
        
    }

    static void LogoutUser(){}

    static void Main(){
        orm.InitDB();

        Task u1 = new Task("Luis", "12345678987", "programing");

        orm.Execute(u1.CreateQuery());

        Console.WriteLine("Bienvenido al Administrador de Tareas");
        Console.WriteLine("Seleccione una opcion:");
        
    }
}
