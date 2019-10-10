using CRUDTeste.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDTeste.Repository
{
    public class PessoasRepository
    {
        private SqlConnection _con;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ToString();

            _con = new SqlConnection(constr);
        }

        //Inserir Pessoa
        public bool AdicionarPessoa(Pessoas pessoasObj)
        {
            Connection();

            int i;
            using (SqlCommand conn = new SqlCommand("IncluirPessoa", _con))
            {
                conn.CommandType = CommandType.StoredProcedure;
                conn.Parameters.AddWithValue("@PessoaNome", pessoasObj.PES_NOME);
                conn.Parameters.AddWithValue("@PessoaCPF", pessoasObj.PES_CPF);
                conn.Parameters.AddWithValue("@PessoaDtnascimento", pessoasObj.PES_DT_NASCIMENTO);

                _con.Open();

                i = conn.ExecuteNonQuery();
            }
            _con.Close();

            return i >= 1;

        }

        //Select de todas as Pessoas
        public List<Pessoas> ObterPessoas()
        {
            Connection();
            List<Pessoas> pessoasList = new List<Pessoas>();

            using (SqlCommand conn = new SqlCommand("ObterPessoas", _con))
            {
                conn.CommandType = CommandType.StoredProcedure;

                _con.Open();

                SqlDataReader reader = conn.ExecuteReader();

                while (reader.Read())
                {
                    Pessoas pessoa = new Pessoas()
                    {
                        PES_ID = Convert.ToInt32(reader["PES_ID"]),
                        PES_NOME = Convert.ToString(reader["PES_NOME"]),
                        PES_CPF = Convert.ToString(reader["PES_CPF"]),
                        PES_DT_NASCIMENTO = Convert.ToString(reader["PES_DT_NASCIMENTO"])
                    };

                    pessoasList.Add(pessoa);
                }

                _con.Close();

                return pessoasList;
            }
        }

        //Update Pessoa
        public bool AtualizarPessoa(Pessoas pessoasObj)
        {
            Connection();

            int i;
            using (SqlCommand conn = new SqlCommand("AtualizarPessoa", _con))
            {
                conn.CommandType = CommandType.StoredProcedure;
                conn.Parameters.AddWithValue("@PessoaId", pessoasObj.PES_ID);
                conn.Parameters.AddWithValue("@PessoaNome", pessoasObj.PES_NOME);
                conn.Parameters.AddWithValue("@PessoaCPF", pessoasObj.PES_CPF);
                conn.Parameters.AddWithValue("@PessoaDtnascimento", pessoasObj.PES_DT_NASCIMENTO);

                _con.Open();

                i = conn.ExecuteNonQuery();
            }
            _con.Close();

            return i >= 1;

        }

        //Excluir Pessoa
        public bool DeletePessoa(int id)
        {
            Connection();

            int i;
            using (SqlCommand conn = new SqlCommand("ExcluirPessoaPorId", _con))
            {
                conn.CommandType = CommandType.StoredProcedure;
                conn.Parameters.AddWithValue("@PessoaId", id);

                _con.Open();

                i = conn.ExecuteNonQuery();
            }
            _con.Close();

            if (i >= 1)
                return true;
            else
                return false;

        }
    }
}