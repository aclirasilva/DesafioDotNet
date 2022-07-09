Imports System.Net.Http
Imports Newtonsoft.Json

Public Class FrmProduto
    Dim Uri As String = "https://localhost:7252/"
    Private Sub btnLista_Click(sender As Object, e As EventArgs) Handles btnLista.Click
        GetProdutos()
    End Sub
    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        GetProdutoId(4)
    End Sub
    Private Async Sub GetProdutos()
        Using client = New HttpClient()
            Dim bsDados As New BindingSource()

            Using response = Await client.GetAsync(Uri + "Produto/GetAll")
                If response.IsSuccessStatusCode Then
                    Dim ProdutoJsonString = Await response.Content.ReadAsStringAsync()
                    dgvDados.DataSource = JsonConvert.DeserializeObject(Of Produto())(ProdutoJsonString).ToList()

                Else
                    MessageBox.Show("Produto Nao localizado" & response.StatusCode)
                End If
            End Using
        End Using
    End Sub
    Private Async Sub GetProdutoId(id As Integer)
        Using client = New HttpClient()
            Dim bsDados As New BindingSource()

            Using response = Await client.GetAsync(Uri + "Produto/GetId?Id=" + id.ToString())
                If response.IsSuccessStatusCode Then
                    Dim ProdutoJsonString = Await response.Content.ReadAsStringAsync()
                    bsDados.DataSource = JsonConvert.DeserializeObject(Of Produto)(ProdutoJsonString)
                    dgvDados.DataSource = bsDados
                Else
                    MessageBox.Show("Produto Nao localizado" & response.StatusCode)
                End If
            End Using
        End Using
    End Sub
End Class
