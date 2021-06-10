<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateGridView.aspx.cs" Inherits="WebFormMlakat.UpdateGridView" %>

<!DOCTYPE html>
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" method="post">
        <div class="jumbotron jumbotron-fluid">
            <div class="container">
                <table>
                    <tr>
                        <td class="label-info">Öğrenci Id:</td>
                        <td>
                            <asp:TextBox ID="txtId" runat="server" ReadOnly="true" />
                        </td>
                        <td></td>
                    </tr>
                    
                    <tr>
                        <td class="label-info">Ders Bilgisi:</td>
                        <td>
                            <asp:TextBox ID="txtOgrDersAdi" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="label-info">Dersin Atandığı Yıl:</td>
                        <td>
                            <asp:TextBox ID="txtDersYil" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="label-info">Dersin Atandığı Dönem:</td>
                        <td>
                            <asp:TextBox ID="txtDersinDönemi" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="label-info">Notu:</td>
                        <td>
                            <asp:TextBox ID="txtNot" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="alert-warning">
                            <asp:Button ID="btnUpdate" runat="server" Text="Güncelle" OnClick="btnUpdate_Click" class="btn btn-warning"/>
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" Text="İptal Et" OnClick="btnCancel_Click" CssClass="btn btn-danger" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
