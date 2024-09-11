Imports System.Data.SqlClient

Public Class DatabaseSettings


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dbMod.server = txt_ServerIP.Text
        dbMod.port = txt_port.Text
        dbMod.user = txt_user.Text
        dbMod.pass = txt_pass.Text
        dbMod.dbSQLServer = txt_dbName.Text

        ConnDBTest()

        dbMod.server = "26.113.153.103" '"localhost" 
        dbMod.port = "3307"
        dbMod.user = "sa"
        dbMod.pass = "CDPabina"
        dbMod.db = "anviz"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dbMod.server = txt_ServerIP.Text
        dbMod.port = txt_port.Text
        dbMod.user = txt_user.Text
        dbMod.pass = txt_pass.Text
        dbMod.dbSQLServer = txt_dbName.Text
    End Sub
End Class