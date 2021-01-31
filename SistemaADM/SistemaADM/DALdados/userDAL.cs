using Sistema_Vendas.BLLClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Vendas.DALdados
{
    class userDAL {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        
        #region selecionar dados do database
        public DataTable Select() {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM tbl_usuario";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            finally {
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region inserir dados no database
        public bool Insert(userBLL u) {
            bool isSucess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try {
                String sql = "INSERT INTO tbl_usuario(pr_nome,sb_nome,email,user_name,password,contato,nm_endereco,sexo,user_type,data,add_por) VALUES (@pr_nome,@sb_nome,@email,@user_name,@password,@contato,@nm_endereco,@sexo,@user_type,@data,@add_por)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pr_nome", u.pr_nome);
                cmd.Parameters.AddWithValue("@sb_nome", u.sb_nome);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@user_name", u.user_name);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@contato", u.contato);
                cmd.Parameters.AddWithValue("@nm_endereco", u.nm_endereco);
                cmd.Parameters.AddWithValue("@sexo", u.sexo);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@data", u.data);
                cmd.Parameters.AddWithValue("@add_por", u.add_por);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0) {
                    isSucess = true;
                }
                else { 
                    isSucess = false; 
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            finally {
                conn.Close();
            }
            return isSucess;
        }
        #endregion

        #region atualizar os dados do database
        public bool update(userBLL u) {
            bool isSucess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try {
                string sql = "UPDATE tbl_usuario SET pr_nome=@pr_nome,sb_nome=@sb_nome,email=@email,user_name=@user_name,password=@password,contato=@contato,nm_endereco=@nm_endereco,sexo=@sexo,user_type=@user_type,data=@data,add_por=@add_por WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pr_nome", u.pr_nome);
                cmd.Parameters.AddWithValue("@sb_nome", u.sb_nome);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@user_name", u.user_name);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@contato", u.contato);
                cmd.Parameters.AddWithValue("@nm_endereco", u.nm_endereco);
                cmd.Parameters.AddWithValue("@sexo", u.sexo);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@data", u.data);
                cmd.Parameters.AddWithValue("@add_por", u.add_por);
                cmd.Parameters.AddWithValue("@id", u.id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0) {
                    isSucess = true;
                }
                else {
                    isSucess = false;
                }
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
            finally {
                conn.Close();
            }
            return isSucess;
        }
        #endregion

        #region deletar os dados do database
        public bool Delete(userBLL u)
        {
            bool isSucess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                string sql = "DELETE FROM tbl_usuario WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);            
                cmd.Parameters.AddWithValue("@id", u.id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSucess = true;
                }
                else
                {
                    isSucess = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSucess;
        }

        internal DataTable Search()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region pesquisa de dados
        public DataTable Search(string keywords) {
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM tbl_usuario WHERE id LIKE '%"+keywords+"%' or pr_name '%"+keywords+"%' or sb_name '%"+keywords+"%' or user_name '%"+keywords+"%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion
    }
}
