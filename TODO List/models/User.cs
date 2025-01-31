class User{
    private ushort id;
    private string name;
    private string password;

    public void InsertUser(){}

    public User(ushort _id, string _name, string _password){
        id = _id;
        name = _name;
        password = _password;
    }

    public string CreateQuery(){
        return $"INSERT INTO users (name, password) VALUES ({name}, {password});";
    }
}