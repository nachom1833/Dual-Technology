<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Site1.Master" AutoEventWireup="true" CodeBehind="DetallesDeVentas.aspx.cs" Inherits="Vistas.Paginas.DetallesDeVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="resto" runat="server">
    <div class="container mt-4">
        <h1 class="mb-4">Detalles de compra</h1>
        <!-- GridView -->
        <div class="row mb-4">
            <div class="col-lg-8">
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnDataBound="GridView1_DataBound">
                    <Columns>
                       <asp:TemplateField HeaderText="Producto">
                           <ItemTemplate>
                                <div class="row">
                                    <div class="col-lg-4">
                                        <br />
                                        <asp:Image ID="imgProducto" class="mr-3" runat="server" width="64" height="64" ImageUrl ='<%# Eval("URL_IMG_Ar") %>'  />
                                        <br />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>  
                                <br />
                                <asp:Label ID="Label3" runat="server" class="mt-0 mb-1" ><%# Eval("Cantidad_DV") %></asp:Label> <asp:Label ID="Label2" runat="server" class="mt-0 mb-1"><%# Eval("Descripcion_Ar ") %></asp:Label> 
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>  
                                 <div class="col-lg-8 text-end">
                                     <div class="media-body">
                                         <br />
                                         <span class="mt-0 mb-1">MONTO : </span><asp:Label ID="LblMonto" runat="server" class="mt-0 mb-1"><%# Eval("PrecioUnitario_Ar") %></asp:Label> 
                                         <br />
                                     </div>
                                 </div>
                            </ItemTemplate>
                       </asp:TemplateField>
                    </Columns>
                 </asp:GridView>
                                <asp:Label ID="Label1" runat="server"/>
            </div>
        </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PieDePagina" runat="server">
</asp:Content>
