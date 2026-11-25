using MySqlConnector;

MySqlConnection connection = new MySqlConnection("Server=localhost;Uid=root;Pwd=insy;");
connection.Open();

while (true)
{
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
                Console.Write($"{reader.GetInt32(0)} - ");
                Console.Write($"{reader.GetString(1)} ");
                Console.WriteLine($"{reader.GetString(2)}");
            }
            reader.Close();
            break;
        case 'C':
            Console.WriteLine("Create");
            string sql = "INSERT INTO htl_matura.Pupils VALUES (@param1,@param2, @param3)";

            cmd = new MySqlCommand(sql, connection);

            Console.WriteLine("ID eingeben");
            cmd.Parameters.AddWithValue("@param1", Console.ReadLine());
            
            Console.WriteLine("Vornamen eingeben");
            cmd.Parameters.AddWithValue("@param2", Console.ReadLine());

            Console.WriteLine("Nachnamen eingeben");
            cmd.Parameters.AddWithValue("@param3", Console.ReadLine());

            cmd.ExecuteNonQuery();
            break;
        case 'U':
            Console.WriteLine("Update");
            sql = "UPDATE htl_matura.Pupils SET FirstName = @param1, LastName = @param2 WHERE Id = @param3";

            cmd = new MySqlCommand(sql, connection);

            Console.WriteLine("Neuen Vornamen eingeben");
            cmd.Parameters.AddWithValue("@param1", Console.ReadLine());
            
            Console.WriteLine("Neuen Nachnamen eingeben");
            cmd.Parameters.AddWithValue("@param2", Console.ReadLine());
            
            Console.WriteLine("ID eingeben");
            cmd.Parameters.AddWithValue("@param3", Console.ReadLine());
            
            cmd.ExecuteNonQuery();
            break;
        case 'D':
            Console.WriteLine("Delete");
            sql = "DELETE FROM htl_matura.Pupils WHERE ID = @param1";

            cmd = new MySqlCommand(sql, connection);

            Console.WriteLine("ID eingeben");
            cmd.Parameters.AddWithValue("@param1", Console.ReadLine());
            cmd.ExecuteNonQuery();
            break;
    }
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
}