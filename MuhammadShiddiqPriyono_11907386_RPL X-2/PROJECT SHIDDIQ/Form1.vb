Public Class Form1
    Dim sqlnya As String
    Dim jk As String
    Dim corona As Integer
    Sub panggildata()
        konek()
        DA = New OleDb.OleDbDataAdapter("SELECT * FROM corona", conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "corona")
        DataGridView1.DataSource = DS.Tables("corona")
        DataGridView1.Enabled = True
    End Sub
    Sub jalan()
        Dim objcmd As New System.Data.OleDb.OleDbCommand
        Call konek()
        objcmd.Connection = conn
        objcmd.CommandType = CommandType.Text
        objcmd.CommandText = sqlnya
        objcmd.ExecuteNonQuery()
        objcmd.Dispose()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call panggildata()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked Then
            jk = "Laki-Laki"
            RadioButton1.Checked = True
        ElseIf RadioButton2.Checked Then
            jk = "Perempuan"
            RadioButton2.Checked = False
        End If
        sqlnya = "insert into corona(nama,nis,umur,jk,point)values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & jk & "','" & TextBox4.Text & "')"
        Call jalan()
        MsgBox("Data Berhasil Tersimpan")
        Call panggildata()
    End Sub
    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        TextBox1.Text = DataGridView1.Item(0, i).Value
        TextBox2.Text = DataGridView1.Item(0, i).Value
        TextBox3.Text = DataGridView1.Item(0, i).Value
        TextBox4.Text = DataGridView1.Item(0, i).Value
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        sqlnya = "UPDATE corona set nama='" & TextBox1.Text & "', nis='" & TextBox2.Text & "',umur='" & TextBox3.Text & "',point='" & TextBox4.Text & "'"
        Call jalan()
        MsgBox("Data Berhasil Terubah")
        Call panggildata()
    End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        sqlnya = "delete from corona where nama='" & TextBox1.Text & "'"
        Call jalan()
        MsgBox("Data Berhasil Dihapus")
        Call panggildata()
    End Sub
End Class
