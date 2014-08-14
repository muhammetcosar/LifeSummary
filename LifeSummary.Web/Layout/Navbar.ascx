<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="LifeSummary.Layout.Navbar" %>
<div class="navbar">
			<div class="navbar-inner">
				<div class="container-fluid">
					<a href="#" class="brand">
						<small>
							<i class="icon-leaf"></i>
							LifeSummary
						</small>
					</a><!--/.brand-->

					<ul class="nav ace-nav pull-right">
 
						<li class="light-blue">
							<a data-toggle="dropdown" href="#" class="dropdown-toggle">
								<asp:Image ID="imgPhoto" runat="server" CssClass="nav-user-photo" ImageUrl="~/Content/assets/avatars/user.jpg" ToolTip="Profil" />
								<span class="user-info">
									<small>  <asp:Label ID="lbuser" runat="server" Text=""></asp:Label></small>
								</span>
								<i class="icon-caret-down"></i>
							</a>

							<ul class="user-menu pull-right dropdown-menu dropdown-yellow dropdown-caret dropdown-closer">
								<li>
                                    <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click" >
										<i class="icon-off"></i>
										Çıkış
									</asp:LinkButton>
                                          
								</li>
							</ul>
						</li>
					</ul><!--/.ace-nav-->
				</div><!--/.container-fluid-->
			</div><!--/.navbar-inner-->
		</div>