using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Referência aos Models criados
using CrudSistemaFitcard.Models;
//Referências ao Banco de Dados
using System.Data;
using System.Data.SqlClient;


//Controlador
namespace CrudSistemaFitcard.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            ViewBag.searchresult = "";
            ViewBag.updateresult = "";

            Estabelecimentos es = new Estabelecimentos();
            es.cnpj = "";
            es.razao_social = "";
            es.nome_fantasia = "";
            es.categoria = "";
            es.email = "";
            es.endereco = "";
            es.cidade = "";
            es.estado = "";
            es.telefone = "";
            es.data_cadastro = "";
            es.status = "";
            es.agencia = "";
            es.conta = "";

            ViewBag.cancelbutton = "disable";
            ViewBag.updatebutton = "disabled";
            ViewBag.deletebutton = "disabled";
            ViewBag.savebutton = "disabled";
            ViewBag.searchbutton = "";
            ViewBag.addnewbutton = "";

            return View(es);
        }
        [HttpPost]

        public ActionResult Index(string cnpj, string cbutton, string razao_social, string nome_fantasia, string categoria, string email, string endereco, string cidade, string estado, string telefone, string data_cadastro, string status, string agencia, string conta)
        {
            Estabelecimentos es = new Estabelecimentos();
            
            //READ
            if (cbutton == "Search")
            {
                String mycon = "Data Source=DESKTOP-4GDBP4U\\SQLEXPRESS; Initial Catalog=CadastroFitcard; Integrated Security=True";
                String myquery = "Select * from estabelecimentos where cnpj=" + Convert.ToInt64(cnpj);
                SqlConnection con = new SqlConnection(mycon);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = myquery;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewBag.searchresult = "CNPJ encontrado!";
                    es.cnpj = cnpj;
                    es.razao_social = ds.Tables[0].Rows[0]["razao_social"].ToString();
                    es.nome_fantasia = ds.Tables[0].Rows[0]["nome_fantasia"].ToString();
                    es.categoria = ds.Tables[0].Rows[0]["categoria"].ToString();
                    es.email = ds.Tables[0].Rows[0]["email"].ToString();
                    es.endereco = ds.Tables[0].Rows[0]["endereco"].ToString();
                    es.cidade = ds.Tables[0].Rows[0]["cidade"].ToString();
                    es.estado = ds.Tables[0].Rows[0]["estado"].ToString();
                    es.telefone = ds.Tables[0].Rows[0]["telefone"].ToString();
                    es.data_cadastro = ds.Tables[0].Rows[0]["data_cadastro"].ToString();
                    es.status = ds.Tables[0].Rows[0]["status"].ToString();
                    es.agencia = ds.Tables[0].Rows[0]["agencia"].ToString();
                    es.conta = ds.Tables[0].Rows[0]["conta"].ToString();
                    ViewBag.updateresult = "Você pode alterar ou deletar esse formulário, ou apenas cancelar a operação";
                    ViewBag.cancelbutton = "";
                    ViewBag.updatebutton = "";
                    ViewBag.deletebutton = "";
                    ViewBag.savebutton = "disabled";
                    ViewBag.addnewbutton = "disabled";
                    



                }

                //Caso o CNPJ não for encontrado
                else
                {
                    ViewBag.updateresult = "";
                    ViewBag.searchresult = "O CNPJ não foi encontrado";
                    ViewBag.cancelbutton = "disabled";
                    ViewBag.updatebutton = "disabled";
                    ViewBag.deletebutton = "disabled";
                    ViewBag.savebutton = "disabled";
                    ViewBag.addnewbutton = "";
                }
                con.Close();


            }

            //UPDATE
            else if (cbutton == "Update")
            {
                String mycon = "Data Source=DESKTOP-4GDBP4U\\SQLEXPRESS; Initial Catalog=CadastroFitcard; Integrated Security=True";
                String updatedata = "Update estabelecimentos set razao_social='" + razao_social + "', nome_fantasia='" + nome_fantasia + "', categoria='" + categoria + "', email='" + email + "', endereco='" + endereco + "', cidade='" + cidade + "', estado='" + estado + "', telefone='" + telefone + "', data_cadastro='" + data_cadastro + "', status='" + status + "', agencia='" + agencia + "', conta='" + conta + "' where cnpj=" + Convert.ToInt64(cnpj);
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updatedata;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                es.cnpj = "";
                es.razao_social = "";
                es.nome_fantasia = "";
                es.categoria = "";
                es.email = "";
                es.endereco = "";
                es.cidade = "";
                es.estado = "";
                es.telefone = "";
                es.data_cadastro = "";
                es.status = "";
                es.agencia = "";
                es.conta = "";
                ViewBag.updateresult = "As alterações foram realizadas com sucesso para o CNPJ " + cnpj;
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.addnewbutton = "";
            }

            else if (cbutton == "Cancel")
            {
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.searchbutton = "";
                ViewBag.addnewbutton = "";
                ViewBag.updateresult = "Novo formulário cancelado";
            }

            //Adiciona todos os campos limpos para o preenchimento de um novo cadastro
            else if (cbutton == "AddNew")
            {
                ViewBag.cancelbutton = "";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "";
                ViewBag.addnewbutton = "disabled";
                ViewBag.searchbutton = "disabled";
                ViewBag.updateresult = "Novo formulário criado!";
            }

            //CREATE
            else if (cbutton == "Save")
            {
                String mycon = "Data Source=DESKTOP-4GDBP4U\\SQLEXPRESS; Initial Catalog=CadastroFitcard; Integrated Security=True";

                String query = "insert into estabelecimentos(cnpj, razao_social, nome_fantasia, categoria, email, endereco, cidade, estado, telefone, data_cadastro, status, agencia, conta) values(" + cnpj + ",'" + razao_social + "','" + nome_fantasia + "','" + categoria + "','" + email + "','" + endereco + "','" + cidade + "','" + estado + "','" + telefone + "','" + data_cadastro + "','" + status + "','" + agencia + "','" + conta + "' )";
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.searchbutton = "";
                ViewBag.addnewbutton = "";
                ViewBag.updateresult = "Cadastro realizado com sucesso!";
            }

            //DELETE
            else if (cbutton == "Delete")
            {
                String mycon = "Data Source=DESKTOP-4GDBP4U\\SQLEXPRESS; Initial Catalog=CadastroFitcard; Integrated Security=True";
                String updatedata = "delete from estabelecimentos where cnpj=" + cnpj;
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = updatedata;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                ViewBag.cancelbutton = "disabled";
                ViewBag.updatebutton = "disabled";
                ViewBag.deletebutton = "disabled";
                ViewBag.savebutton = "disabled";
                ViewBag.searchbutton = "";
                ViewBag.addnewbutton = "";
                ViewBag.updateresult = "Cadastro deletado do seguinte CNJP: " + cnpj;
            }




            return View(es);
        }


    }
}
    
