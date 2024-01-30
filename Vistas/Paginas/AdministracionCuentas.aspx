<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Site1.Master" AutoEventWireup="true" CodeBehind="AdministracionCuentas.aspx.cs" Inherits="Vistas.Paginas.AdministracionCuentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="resto" runat="server">
    <asp:ListView ID="LvCuentas" runat="server" GroupItemCount="3" OnItemDataBound="LvCuentas_ItemDataBound " OnItemCommand="LvCuentas_ItemCommand">
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
    <div class="d-flex justify-content-center align-items-center">
        <td class="col-md-4 mb-4">
            <div class="card">
            <h4 ><strong><asp:Label ID="Cod_Cuenta_CuLabel1" runat="server" Text='<%# Eval("Cod_Cuenta_Cu") %>' /></strong></h4>
            <div class="card-body">
                <h5 class="card-title">
                    Nombre de usuario
                     <span class="job_post"><asp:label ID="TxtUsuario" runat="server" Text='<%# Bind("Nombre_Usuario_Cu") %>' /></span>

                </h5>
                <div class="profile-image float-md-end"> <img src="https://bootdey.com/img/Content/avatar/avatar7.png" alt=""> </div>
                <p class="card-text">
                <span class="job_post"><asp:label ID="Email_CuTextBox" runat="server" Text='<%# Bind("Email_Cu") %>' /></span>
                <p class="card-text">
                     <asp:CheckBox ID="EstadoCheckBox" runat="server" Checked='<%# Bind("Estado") %>' Text="Estado" Enabled="false" CssClass="form-check"/>
                </p>
                <p class="card-text">
                    <asp:CheckBox ID="Admin_CuCheckBox" runat="server" Checked='<%# Bind("Admin_Cu") %>' Text="Admin_Cu" Enabled="false" CssClass="form-check" />
                </p>
                                <asp:Button ID="BtnDarAdmin" runat="server"  class="btn btn-primary" Text="Dar admin" CommandName="Dar" />
                                <asp:Button ID="BtnQuitarAdmin" runat="server"  class="btn btn-primary" Text="Quitar Admin" CommandName="Quitar"/>
                                <asp:Button ID="BtnEliminarCuenta" runat="server"  class="btn btn-danger" Text="Eliminar cuenta" CommandName="Eliminar"/>
                                <asp:Button ID="BtnDarAlta" runat="server"  class="btn btn-danger" Text="Dar alta" CommandName="DarDeAlta"/>
            </div>
        </div>
    </td>
</td>
    </td>
</ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                                    <tr id="groupPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                   <asp:DataPager ID="DataPager1" runat="server" PageSize="12" OnPreRender="DataPager1_PagePropertiesChanged" >
                            <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="True" ShowPreviousPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                      </asp:DataPager>
                               
                            </td>
                        </tr>
                    </table>    
                </LayoutTemplate>
            </asp:ListView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PieDePagina" runat="server">
</asp:Content>
