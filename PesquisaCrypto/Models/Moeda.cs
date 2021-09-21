using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PesquisaCrypto.Models
{
    public class Moeda
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public bool CheckBoxMarcado { get; set; }


        public static void InsertUpdate(Moeda moeda)
        {
            MySqlCommand cmd = new MySqlCommand("");
            if (moeda.Id > 0)
            {
                cmd = new MySqlCommand("UPDATE moeda SET nome = @nome, quantidade = @quantidade WHERE id = @id");
                cmd.Parameters.AddWithValue(@"id", moeda.Id);
            }
            else cmd = new MySqlCommand("INSERT INTO moeda (nome, quantidade) VALUES (@nome, @quantidade);");
            cmd.Parameters.AddWithValue(@"nome", moeda.Nome);
            cmd.Parameters.AddWithValue(@"quantidade", moeda.Quantidade);

            Access.ExecuteNonQuery(cmd);
        }

        public static IEnumerable<Moeda> GetAll()
        {
            List<Moeda> result = new List<Moeda>();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM moeda");
            foreach (DataRow dr in Access.ExecuteReader(cmd).Tables[0].Rows)
            {
                result.Add(new Moeda(dr));
            }

            return result;
        }

        public Moeda()
        {
            Id = -1;
            Nome = "";
            Quantidade = 0;
        }
        public Moeda(DataRow dr)
        {
            Id = int.Parse(dr["id"].ToString());
            Nome = dr["nome"].ToString();
            Quantidade = int.Parse(dr["quantidade"].ToString());
        }
    }
}
