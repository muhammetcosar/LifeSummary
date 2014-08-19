<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LifeSummary.Login" %>

<%@ Register Src="~/Layout/Head.ascx" TagPrefix="uc1" TagName="Head" %>
<%@ Register Src="~/Layout/Footer.ascx" TagPrefix="uc1" TagName="Footer" %>





<!DOCTYPE html>
<html lang="en">
	<head>
		<meta charset="utf-8" />
		<title>LifeSummary</title>

		<meta name="description" content="User login page" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0" />

		<!--basic styles-->

        <uc1:Head runat="server" ID="Head" />

		<!--inline styles related to this page-->
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        
        <style type="text/css">
            #txtKayit {
                text-align: left;
            }
        </style>
    </head>

	<body class="login-layout">
         <form id="form1" runat="server">
		<div class="main-container container-fluid" id="txtgiris" runat="server">
			<div class="main-content">
				<div class="row-fluid">
					<div class="span12">
						<div class="login-container">
							<div class="row-fluid">
								<div class="center">
									<h1>
										<i class="icon-leaf green">Muhammet</i>COŞAR
									</h1>
									<h4 class="blue">© main-container container-fluid</h4>
								</div>
							</div>
							<div class="space-6"></div>
							<div class="row-fluid" >
								<div class="position-relative">
									<div id="login-box" class="login-box visible widget-box no-border">
										<div class="widget-body">
											<div class="widget-main">
												<h4 class="header blue lighter bigger">
													<i class="icon-coffee green"></i>
													Sisteme Giriş
												</h4>

												<div class="space-6"></div>
                                               
												
													<fieldset>
														<label>
															<span class="block input-icon input-icon-right">
                                                                <asp:TextBox ID="txtUsername"  class="span12" runat="server"/>
																<i class="icon-user"></i>
															</span>
														</label>

														<label>
															<span class="block input-icon input-icon-right">
                                                                <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password" class="span12" ></asp:TextBox>
																
																<i class="icon-lock"></i>
															</span>
														</label>

														<div class="space"></div>

														<div class="clearfix">
															 
                                                           
                                                            <asp:Button ID="BtnLogin" runat="server" Text="Giris" OnClick="BtnLogin_Click"/>
														</div>
                                                        
														<div class="space-4"> </div>
													</fieldset>
												
                         
												 
											</div><!--/widget-main-->

											<div class="toolbar clearfix">
												
											</div>
										</div><!--/widget-body-->
									</div><!--/login-box-->
								</div><!--/position-relative-->
							</div>

                            
							</div>
					</div><!--/.span-->
				</div><!--/.row-fluid-->
			</div>

		</div><!--/.main-container-->
             
</form>
        <uc1:Footer runat="server" ID="Footer" />

		<script type="text/javascript">
		    function show_box(id) {
		        $('.widget-box.visible').removeClass('visible');
		        $('#' + id).addClass('visible');
		    }
		</script>
	</body>
</html>

