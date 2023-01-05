using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DaimaProje2.Models
{
    public class DP
    {
        private static string connectionString =
        @"Server=316-14\SQLEXPRESS; Database=Diama; uid=sa; pwd=I$kur2022#!";
        //private static string connectionString =
        /*@"Server=FAKYURT\SQLEXPRESS; Database=Diama; integrated security=true";	*/	//SQL baglantısı ıcın Sqlconnection kullanmadan string ifadeyle baglantı sagladık

        public static void ExecuteWReturn(string procadi, DynamicParameters param = null)		//ekleme silme yenileme icin bunu kullanuyoruz, baglantıyı acıyor.
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))			//constructor  oalrak belirledik connectionSTring i, bu nesne calısır calısmaz veritabanına baglantı saglıyor.
            {
                baglanti.Open();
                baglanti.Execute(procadi, param, commandType: CommandType.StoredProcedure);

            }
        }

        public static T ExecuteReturnScalar<T>(string procadi, DynamicParameters param = null)
        {
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                return (T)Convert.ChangeType
                    (baglanti.ExecuteScalar(procadi, param, commandType: CommandType.StoredProcedure), typeof(T));

            }
        }

        public static IEnumerable<T> ReturnList<T>(string procadi, DynamicParameters param = null)		//Ienumarable foreach gibi her seyi listeliyo, T bir class kullanacgımız anlamına geliyor, hangi class icin kullanılmasını
        {

            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                return baglanti.Query<T>(procadi, param, commandType: CommandType.StoredProcedure);

            }
        }
    }
}