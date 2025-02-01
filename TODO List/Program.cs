using System.ComponentModel.DataAnnotations;

class Program
{
    static ORM orm = new ORM("Data Source=db.db;Version=3;");

    static public bool ValidateRang(int value, int min, int max){
        if(value < min || value > max) return false;
        else return true;
    }

    static public int Operation(int min, int max){
        while(true){
            try {
                int op = int.Parse(Console.ReadLine());
                if(!ValidateRang(op, min, max)) throw new IOException();
                return op;
            } catch(FormatException){
                Console.WriteLine("Debe de colocar un valor entero");
            } catch(IOException){
                Console.WriteLine("Debe de colocar un numero dentro del rango");
            }
        }
        
    }

    static void Main(){
        orm.InitDB();

        while(true){
            Console.WriteLine("\nBienvenido al Administrador de Tareas");
            Console.WriteLine("Seleccione una opcion:\n");
            Console.WriteLine("-1- Crear Tarea \t-2- Listar Tareas");
            Console.WriteLine("-3- Actualizar Tarea \t-4- Eliminar Tarea");
            Console.WriteLine("-5- Salir");
            Console.WriteLine("\n");
            
            int op = Operation(1, 5);

            if(op == 1){
                string title = Console.ReadLine()       ?? "None";
                string description = Console.ReadLine() ?? "None";
                string category = Console.ReadLine()    ?? "None";
                orm.Execute($"INSERT INTO tasks (title, description, category) VALUES (\"{title}\", \"{description}\", \"{category}\");");
            }
            if(op == 2) orm.ListData();
            if(op == 3){
                orm.ListData();
                while(true){
                    Console.WriteLine("\nSelecciones el ID de la Tarea a Actualizar\n");
                    int id = int.Parse(Console.ReadLine());
                    if(orm.CheckID(id)){
                        Console.WriteLine("\nID Invalido\n");
                        continue;
                    } else {
                        Console.WriteLine("\n Diga los nuevos valores: \n");
                        string title = Console.ReadLine()       ?? "None";
                        string description = Console.ReadLine() ?? "None";
                        string category = Console.ReadLine()    ?? "None";
                        orm.Execute($"UPDATE tasks SET title = {title}, description = {description}, category = {category} WHERE id = {id};");
                        break;
                    }
                }
            }
            if(op == 4) {
                orm.ListData();
                while(true){
                    Console.WriteLine("\nSelecciones el ID de la Tarea a Eliminar\n");
                    int id = int.Parse(Console.ReadLine());
                    if(orm.CheckID(id)){
                        Console.WriteLine("\nID Invalido\n");
                        continue;
                    } else {
                        orm.Execute($"DELETE FROM tasks WHERE id = {id}");
                        break;
                    }
                }
            }
            if(op == 5) break;
        }
    }
}
