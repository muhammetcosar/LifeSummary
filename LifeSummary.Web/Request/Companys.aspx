﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Companys.aspx.cs" Inherits="LifeSummary.Request.sirket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="span6">
        <div class="widget-box">
            <div class="widget-header">
                <h5>Şirket</h5>
            </div>
            <div class="widget-body">
                <div class="widget-main">
                    <div class="control-group">
                        <asp:DropDownList ID="DlCity" runat="server" DataTextField="CityName" AutoPostBack="True" DataValueField="CityId" OnSelectedIndexChanged="DlCity_SelectedIndexChanged"
                             >
                        </asp:DropDownList>
                    </div>
                    <div class="control-group">
                        <asp:ListBox ID="lbCompany" runat="server" DataTextField="CompanyTitle" Height="227px" Width="292px"  DataValueField="CompanyId" AutoPostBack="True" OnSelectedIndexChanged="lbCompany_SelectedIndexChanged"></asp:ListBox>
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
                        <label class="control-label" for="form-field-1">Şirket</label>
                        <div class="controls">
                            <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-actions">
                         <asp:Button ID="btnSave" class="btn btn-info" runat="server" Text="Kaydet" OnClick="btnSave_Click"   />
                        <asp:Button ID="btnNew" class="btn btn-info" runat="server" Text="Yeni" OnClick="btnNew_Click" />
                        <asp:Button ID="btnDelete" class="btn btn-info" runat="server" Text="Sil" OnClick="btnDelete_Click"  />
                        <asp:HyperLink ID="btnCancel" class="btn btn-warn" runat="server"  Text="İptal" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
