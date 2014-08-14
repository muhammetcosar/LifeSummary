<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Sidebar.ascx.cs" Inherits="LifeSummary.Layout.Sidebar" %>
<div class="sidebar" id="sidebar">
				<div class="sidebar-shortcuts" id="sidebar-shortcuts">
					<div class="sidebar-shortcuts-large" id="sidebar-shortcuts-large">
						
						
						
					
					</div>

					 
				</div><!--#sidebar-shortcuts-->

				<ul class="nav nav-list">
                    <li>
						<asp:HyperLink runat="server" ID="lnkRequest" NavigateUrl="~/Request/Manage">
							<i class="icon-desktop"></i>
							<span class="menu-text"> Anasayfa </span>
						</asp:HyperLink>

					</li>
                     <li>
						<asp:HyperLink runat="server" ID="lnkCity" NavigateUrl="~/Request/sehirler">
							<i class="icon-desktop"></i>
							<span class="menu-text"> Şehirler </span>
						</asp:HyperLink>

					</li>
                    <li>
						<asp:HyperLink runat="server" ID="lnkCategory" NavigateUrl="~/Request/Category">
							<i class="icon-desktop"></i>
							<span class="menu-text"> Kategori </span>
						</asp:HyperLink>

					</li>
                     <li>
						<asp:HyperLink runat="server" ID="lnkCompany" NavigateUrl="~/Request/sirket">
							<i class="icon-desktop"></i>
							<span class="menu-text"> Şirket </span>
						</asp:HyperLink>

					</li>
                     <li>
						<asp:HyperLink runat="server" ID="lnkPerson" NavigateUrl="~/Request/person">
							<i class="icon-desktop"></i>
							<span class="menu-text"> Kişi </span>
						</asp:HyperLink>

					</li>
				</ul><!--/.nav-list-->

			</div>