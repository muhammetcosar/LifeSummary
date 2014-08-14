<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="LifeSummary.Contact" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <li class="active">Anasayfa</li>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span6">
        <div class="widget-box">
            <div class="widget-header">
                <h5>Anasayfa</h5>
            </div>
            <div class="widget-body">
                <div class="widget-main">
                    <div class="control-group">
                        <asp:Label ID="Label2" runat="server" Text="Tanıştıgın"></asp:Label>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Yer"></asp:Label>

                        <asp:DropDownList ID="DlCategory" runat="server" DataTextField="CategoryName" AutoPostBack="True" OnSelectedIndexChanged="Category_SelectedIndexChanged"></asp:DropDownList>
                        <br />
                        <div class="controls" id="Cdiger" visible="false" runat="server">
                            <asp:TextBox ID="txtdiger" runat="server"></asp:TextBox>
                        </div>
                        <asp:Label ID="Label4" runat="server" Text="Ülke"></asp:Label>
                        <asp:TextBox ID="txtUlke" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Şehir"></asp:Label>
                        <asp:TextBox ID="txtSehir" runat="server"></asp:TextBox>
                    </div>
                    <div class="control-group">
                        <asp:Label ID="Label3" runat="server" Text="Calıştığın"></asp:Label>
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="Yer"></asp:Label>
                        <asp:TextBox ID="txtYer" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="Ülke"></asp:Label>
                        <asp:TextBox ID="txtUlke2" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-actions">


                        <asp:Button ID="Button1" class="btn btn-info" runat="server" OnClick="btnSave_Click" Text="Gönder" />


                    </div>


                </div>
            </div>
        </div>
    </div>

    <div class="span6">
        <div class="widget-header">
            <h5>Detay</h5>


        </div>
        <div class="widget-body">
            <div class="widget-main">
                <div class="form-horizontal">

                    <div class="control-group">
                        <label class="control-label" for="form-field-1">Ögrenci No</label>
                        <div class="controls">
                            <asp:TextBox ID="txtUser" runat="server" ReadOnly="true"></asp:TextBox>

                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="form-field-1">Adı</label>
                        <div class="controls">
                            <asp:TextBox ID="txtName" runat="server" ReadOnly="true"></asp:TextBox>

                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="form-field-1">Soyadı</label>
                        <div class="controls">
                            <asp:TextBox ID="txtSurname" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="form-field-1">Tc</label>
                        <div class="controls">
                            <asp:TextBox ID="tc" runat="server" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="control-group" runat="server" id="cgOther" visible="false">
                        <div class="controls">
                        </div>
                    </div>




                    <div class="form-actions">


                        <asp:Button ID="btnSave" class="btn btn-info" runat="server" OnClick="btnSave_Click" Text="Kaydet" />
                        <asp:HyperLink ID="btnCancel" class="btn btn-warn" runat="server" OnClick="btnCancel_Click" Text="İptal" />

                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
