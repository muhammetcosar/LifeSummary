<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Citys.aspx.cs" Inherits="LifeSummary.Request.sehirler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="span6">
        <div class="widget-box">
            <div class="widget-header">
                <h5>Şehirler</h5>
            </div>
            <div class="widget-body">
                <div class="widget-main">
                    <div class="control-group">
                        <asp:DropDownList ID="Dlcountry" runat="server" DataTextField="COUNTRYNAME" AutoPostBack="True" DataValueField="COUNTRYID" OnSelectedIndexChanged="Dlcountry_SelectedIndexChanged"  >
                        </asp:DropDownList>
                    </div>
                    <div class="control-group">
                        <asp:ListBox ID="lbCity" runat="server" DataTextField="CityName" Height="86px" Width="216px"  DataValueField="CityId" AutoPostBack="True" OnSelectedIndexChanged="lbCity_SelectedIndexChanged" ></asp:ListBox>
                    </div>
                    <div class="form-actions">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="span6" runat="server" id="duzen" visible="false">
        <div class="widget-header">
            <h5>Düzenle</h5>
        </div>
        <div class="widget-body">
            <div class="widget-main">
                <div class="form-horizontal">

                    <div class="control-group">
                        <label class="control-label" for="form-field-1">Sehir</label>
                        <div class="controls">
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-actions">
                         <asp:Button ID="Button1" class="btn btn-info" runat="server" Text="Düzenle" OnClick="edit_Click"   />
                        <asp:Button ID="Button2" class="btn btn-info" runat="server" Text="Ekle" OnClick="ekle_Click"  />
                        <asp:Button ID="Button3" class="btn btn-info" runat="server" Text="Sil" OnClick="Delete_Click"   />
                        <asp:HyperLink ID="HyperLink1" class="btn btn-warn" runat="server"  Text="İptal" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
