<Query Kind="Program">
  <Output>DataGrids</Output>
</Query>

void Main()
{
	var dtDataTable = retrieveCustomFieldsLabel();
	foreach (DataColumn dc in dtDataTable.Columns)
	{
		Console.Write($"{dc.ColumnName,25}");
	}	
	Console.WriteLine();
	foreach (DataRow row in dtDataTable.Rows)
	{	
		foreach (DataColumn dc in dtDataTable.Columns)
		{
			Console.Write($"{row[dc].ToString(),25}");
		}
		Console.WriteLine();
	}
}

private static DataTable retrieveCustomFieldsLabel()
{
    var dtDataTable = new DataTable("Results");

    using (var conn = new SqlConnection(@"Data Source=lasrv4\lasql2012; Initial Catalog=DanielGroup; User ID=dg; Password=dg;Connect Timeout=200; pooling='true'; Max Pool Size=200"))
    {
        conn.Open();
        using (var command = new SqlCommand("select pkeyClientContactID,fkeyClientID,fkeyCustomerID,dtmDateAdded,fkeyAddUserID,dtmDateLastUpdated from ttblClientContacts", conn))
        {
			command.CommandType = CommandType.Text;       

            //command.Parameters.AddWithValue("@fkeyClientID", fkeyClientID);
            var sdaAdapter = new SqlDataAdapter();
            sdaAdapter.SelectCommand = command;

            var dsDataSet = new DataSet();
            sdaAdapter.Fill(dsDataSet);
            dtDataTable = dsDataSet.Tables[0];
        }
    }
    return dtDataTable;
}
