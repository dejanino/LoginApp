using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApplication
{
    public static class DataAdapters
    {
        public static SqlDataAdapter EmployeeAdapter(SqlConnection conn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            //create sql select command
            SqlCommand sCommand = new SqlCommand("SELECT * FROM Employee", conn);
            adapter.SelectCommand = sCommand;

            // create sql insert command
            SqlCommand iCommand = new SqlCommand("INSERT INTO Employee (FirstName, LastName, Gender) " +
                "VALUES (@FirstName, @LastName, @Gender)", conn);
            // add the parameters for iCommand
            iCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100, "FirstName");
            iCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 100, "LastName");
            iCommand.Parameters.Add("@Gender", SqlDbType.NChar, 1, "Gender");

            adapter.InsertCommand = iCommand;

            //create sql update command
            string uQuery = "UPDATE Employee SET LastName=@LastName WHERE Id=@EmployeeId";
            SqlCommand uCommand = new SqlCommand(uQuery, conn);
            // add the parameters for uCommand
            uCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 100, "LastName");
            SqlParameter uid = uCommand.Parameters.Add("@EmployeeId", SqlDbType.Int, 100, "Id");
            uid.SourceVersion = DataRowVersion.Original;

            adapter.UpdateCommand = uCommand;

            // create sql delete command
            SqlCommand dCommand = new SqlCommand("DELETE FROM Employee WHERE Id=@EmployeeId", conn);
            //add the parameters for delete command
            SqlParameter did = dCommand.Parameters.Add("@EmployeeId", SqlDbType.Int, 100, "Id");
            did.SourceVersion = DataRowVersion.Original;

            adapter.DeleteCommand = dCommand;

            return adapter;
        }
    }
}
