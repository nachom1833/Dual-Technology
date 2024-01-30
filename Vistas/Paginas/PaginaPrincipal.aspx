<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Site1.Master" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="Vistas.Paginas.PaginaPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Resto" runat="server">
    <style>
    .Black
    {
    filter: invert(100%) sepia(0%) saturate(0%) hue-rotate(0deg) brightness(100%) contrast(100%);
    }
    .espaciado 
    {
            margin-left: 0px;
    }
</style>
<div id="carouselExampleAutoplaying" class="carousel slide" data-bs-ride="carousel">
    <div class="carousel-inner">
        <div class="carousel-item active ">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/ImagenesPublicidad/avatar-home-1920x504.jpg" class="d-block w-100" />
        </div>
        <div class="carousel-item ">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/ImagenesPublicidad/logitech-g-1920x504-1.jpg" class="d-block w-100" />
        </div>
        <div class="carousel-item">
            <asp:Image ID="Image3" runat="server" ImageUrl="~/ImagenesPublicidad/newbeastddr4-rgb-1920x504.jpg" class="d-block w-100" />
        </div>
    </div>
    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleAutoplaying" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
    </button>
</div>
 <p class="h1"> Productos desctacados</p>
<div class="container my-4 w-50 espaciado">
    <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
        <!-- Diapositivas -->
        <div class="carousel-inner">
            <asp:Repeater ID="CardRepeater" runat="server">
                <ItemTemplate>
                    <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                        <div class="card bg-white text-dark m-width-100">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="card-body">
                                        <h5 class="card-title"><%# Eval("Descripcion_Ar") %></h5>
                                        <p class="display-1"><%# Eval("PrecioUnitario_Ar") %></p>
                                        <br><br><br><br><br><br>
                                        <asp:Button ID="BtnMoverAProductos" runat="server" Text="VER PRODUCTOS" class="btn btn-primary btn-lg" PostBackUrl="~/Paginas/Productos.aspx" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <asp:Image ID="CardImage" runat="server" ImageUrl='<%# Eval("URL_IMG_Ar") %>' CssClass="img-fluid" />
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!-- Controles -->
        <button class="carousel-control-prev Black" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next Black" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PieDePagina" runat="server">
</asp:Content>
