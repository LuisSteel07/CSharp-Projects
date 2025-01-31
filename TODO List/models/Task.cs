class Task{
    private string title;
    private string description;
    private string category;

    public Task(string _title, string _description, string _category){
        title = _title;
        description = _description;
        category = _category;
    }

    public string CreateQuery(){
        return $"INSERT INTO tasks (title, description, category) VALUES (\"{title}\", \"{description}\", \"{category}\");";
    }
}