<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="hakkimizda.aspx.cs" Inherits="Lerinvest.hakkimizda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/js/jquery-1.11.0.min.js"></script>

    <script type="text/javascript">
        jQuery(document).ready(function () {
            $($(".nav-tabs").children()[0]).attr("class", "active");
            $($(".tab-content").children()[0]).attr("class", "tab-pane animated-6s flipInX active");
        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--======= BANNER =========-->
    <div class="sub-banner">
        <div class="overlay">
            <div class="container">
                <h1>HAKKIMIZDA</h1>
                <ol class="breadcrumb">
                    <li class="pull-left">HAKKIMIZDA</li>
                    <li><a href="/">Ana Sayfa</a></li>
                    <li class="active">HAKKIMIZDA</li>
                </ol>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="col-md-12 margin-b-40">
            <asp:Literal ID="ltrhakkimizda" runat="server" />
        </div>
    </div>

    <!--======= WHAT WE DO =========-->
    <section class="what-we-do">
        <div class="container">



            <!--======= TITTLE =========-->
            <div class="tittle">
                <img src="images/head-top.png" alt="">
                <h3>Şirket Profili</h3>
                <p>Uluslararası Gayrimenkul Yatırımları.</p>
            </div>
            <div role="tabpanel">

                <!--======= NAV TABS =========-->
                <ul class="nav nav-tabs" role="tablist">
                    <asp:Repeater runat="server" ID="rptHakkimizdaKategoriBaslik">
                        <ItemTemplate>
                            <li role="presentation">
                                <a href='#<%# Eval("ID") %>' aria-controls="home" role="tab" data-toggle="tab">
                                    <i class='<%# Eval("icon") %>'></i>
                                    <span class="font-montserrat"><%# Eval("Baslik") %></span></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>

                <!--======= TAB CONTENT =========-->
                <div class="tab-content">

                    <!--======= WHAT WE DO =========-->
                    <asp:Repeater runat="server" ID="rptHakkimzdaKategoriIcerik">
                        <ItemTemplate>
                            <div role="tabpanel" class="tab-pane animated-6s flipInX" id='<%# Eval("ID") %>'>
                                <h4><%# Eval("Baslik") %></h4>
                                <p><%# Eval("Icerik") %></p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                </div>
            </div>
        </div>
    </section>

    <!--======= CALL US =========-->

    <section class="call-us">
        <div class="overlay">
            <div class="container">
                <ul class="row">
                    <li class="col-sm-7">
                        <h4>Karlı mülkleri mi arıyorsunuz? </h4>
                        <h6>Ayrıntılar için bizi arayın</h6>
                    </li>
                    <li class="col-sm-3">
                        <h1>
                            <asp:Literal ID="ltrtel" runat="server" /></h1>
                    </li>
                    <li class="col-sm-2 no-padding"><a href="/Contact" class="btn"> iletişime geç </a> </li>
                </ul>
            </div>
        </div>
    </section>

    <!--======= PARTHNER =========-->
    <section class="parthner">
        <div class="container">
            <!--======= TITTLE =========-->
            <%--<div class="tittle">
                <img src="images/head-top.png" alt="">
                <h3>our trusted partners</h3>
                <p>This time there's no stopping us. Straightnin' the curves. Flatnin' the hills Someday the mountain might get ‘em but the law never will. The weather started getting rough - the tiny ship was tossed.</p>
            </div>--%>

            <!--======= PARTHNERS =========-->
            <div class="parthner-slide">
                <asp:Repeater runat="server" ID="rptReferanslar">
                    <ItemTemplate>
                        <%--<div class="part">
                            <a href='<%# Eval("Link") %>'>
                                <img src='<%# Eval("ResimYol") %>' alt='<%# Eval("Alt") %>' width="90" height="75">
                            </a>
                        </div>--%>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
</asp:Content>
