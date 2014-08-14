<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Person.aspx.cs" Inherits="LifeSummary.Request.Person" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span6">
        <div class="widget-box">
            <div class="widget-header">
                <h5>Anasayfa</h5>
            </div>
            <div class="widget-body">
                <div class="widget-main">
                    <div class="control-group">

                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Adı"></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Soyadı"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>

                                </td>

                            </tr>
                            <tr>
                                <td style="height: 26px">
                                    <asp:Label ID="Label2" runat="server" Text="Başlık"></asp:Label>

                                </td>
                                <td style="height: 26px">
                                   
                                     <asp:DropDownList ID="dlTitle" runat="server" DataTextField="TitleName" DataMember="TitleId" DataValueField="TitleId"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Konu"></asp:Label>

                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>

                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="sehirler"></asp:Label>

                                </td>
                                <td>
                                    <asp:DropDownList ID="dlcity" runat="server" DataTextField="CityName" DataMember="CityId" DataValueField="CityId"></asp:DropDownList>
                                  

                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="buluşma tarihi"></asp:Label>

                                </td>
                                <td>
                                  
                                    <asp:Calendar ID="itarih" runat="server"></asp:Calendar>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="ayrılma tarihi"></asp:Label>

                                </td>
                                <td>
                                   <asp:Calendar ID="atarih" runat="server"></asp:Calendar>

                                </td>
                            </tr>
                            
                            
                        </table>
                    </div>


                    <div class="form-actions">
                        <asp:Button ID="Save" class="btn btn-info" runat="server" Text="Gönder" OnClick="Save_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
