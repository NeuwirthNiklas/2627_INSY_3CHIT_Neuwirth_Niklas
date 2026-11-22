using MySqlConnector;

MySqlConnection connection = new MySqlConnection("Server=localhost;Uid=root;Pwd=insy;");
connection.Open();

Console.WriteLine("Wählen sie aus was sie tun möchten");
Console.WriteLine("(C)reate");
Console.WriteLine("(R)ead");
Console.WriteLine("(U)pdate");
Console.WriteLine("(D)elete");
ConsoleKeyInfo input = Console.ReadKey();
Console.WriteLine("");

switch (input.KeyChar)
{
    case 'R':
        Console.WriteLine("Read");
        MySqlCommand cmd = new MySqlCommand("SELECT * FROM htl_matura.Pupils", connection);
        MySqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.Write($"{reader.GetInt32(0)}-");
            Console.Write($"{reader.GetString(1)} ");
            Console.WriteLine($"{reader.GetString(2)}");
        }
        break;
}