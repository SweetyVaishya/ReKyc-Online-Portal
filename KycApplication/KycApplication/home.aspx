<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="KycApplication.home" %>

<!doctype html>
<html lang="en">
<head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous">

    <title></title>

    <style>
        header li {
            display: inline;
        }

            header li a {
                color: black;
            }

        nav li {
            display: inline;
            margin: 0 10px 0 10px;
        }

        a {
            text-decoration: none !important
        }

        nav li a {
            color: white;
            padding: 10px;
            padding-bottom: 26px;
        }

            nav li a:hover {
                color: black;
                background-color: #ffe600;
            }

        .carousel-item {
            width: 100%;
        }
    </style>
</head>
<body>

    <header style="background-color: #ffe600;">
        <div class="row">
            <div class="col-md-2">
                <a class="navbar-brand" href="admhome.aspx">
                    <img src="Content/img/logoabhudaya.png" class="pl-5" /></a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
            </div>

            <div class="col-md-6">
                <ul class=" ml-3 mt-3 ">
                    <li><a href="#">Home </a></li>
                    <li>|</li>
                    <li><a href="#">About Us </a></li>
                    <li>|</li>
                    <li><a href="#">Customer Services</a></li>
                    <li>|</li>
                    <li><a href="#">Tender</a></li>
                    <li>|</li>
                    <li><a href="#">Career</a></li>
                    <li>|</li>
                    <li><a href="#">FAQ</a></li>
                    <li>|</li>
                    <li><a href="#">Sitemap</a></li>
                    <li>|</li>
                    <li><a href="#">Contact Us</a></li>
                </ul>
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-inline ml-5">
                            <input class=" form-control " type="search" placeholder="Search here" aria-label="Search">
                            <button class="" type="submit">
                                <img src="Content/img/search.png" height="25px" width="20px" /></button>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <%--<h4 class="text-info text-center">CALL CENTER @ 1800223131</h4>--%>
                        <img src="Content/img/callcenter.png" class="img-responsive">
                    </div>
                </div>
            </div>

            <div class="col-md-4 text-center">
                <ul class=" mt-4 ">
                    <li><a href="#">हिंदी </a></li>
                    <li>|</li>
                    <li><a href="#">मराठी </a></li>
                    <li class="ml-3"><a href="#">Abhimaan Geet </a></li>
                </ul>
                <div class="row ml-5">
                    <p class="text-center text-info">Friday, 10 Mar 2023 15:51 pm</p>
                </div>
            </div>

        </div>
    </header>

    <nav class="navbar navbar-expand-lg m-auto" style="background-color: #016CB2;">
        <ul class="text-center">
            <li><a href="#">Deposites </a></li>
            <li><a href="#">Loans</a></li>
            <li><a href="#">Forex & Trade</a></li>
            <li><a href="#">Banking Channels</a></li>
            <li><a href="#">Interest Rates</a></li>
            <li><a href="#">Service Charges</a></li>
            <li><a href="#">Payments Services</a></li>
            <li><a href="#">e-Auction</a></li>
            <li><a href="Default.aspx">Online Re-KYC Portal</a></li>
        </ul>
    </nav>



    <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="Content/img/s1.jpg" class="d-block  img-fluid" style="width: 100%" alt="...">
            </div>
            <div class="carousel-item">
                <img src="Content/img/s2.jpg" class="d-block img-fluid" style="width: 100%" alt="...">
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-target="#carouselExampleControls" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-target="#carouselExampleControls" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </button>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-4">
            </div>
            <div class="col-4">
            </div>
            <div class="col-4">
            </div>
        </div>
    </div>


    <div class="container mt-3">
        <div class="row">
            <div class="col-md-6">
                <div class="card" style="background-color: #016CB2; color: white">
                    <h4 class="text-center">Find your nearest</h4>
                    <ul style="margin: 1rem 6px;">
                        <li class="whitefontcolor"><a href="FindAtm.aspx" class="text-light">ATM</a></li>
                        <li class="whitefontcolor"><a href="FindBranch.aspx" class="text-light">Branch </a></li>
                        <li class="whitefontcolor"><a href="Department-Contact.aspx" class="text-light">Department</a></li>
                        <li class="whitefontcolor"><a href="Other-services.aspx" class="text-light">Franking </a></li>
                        <li class="whitefontcolor"><a href="Locker.aspx" class="text-light">Locker</a></li>
                        <li class="whitefontcolor"><a href="Forex-Service.aspx" class="text-light">Forex Services </a></li>
                        <li class="whitefontcolor"><a href="Sunday.aspx" class="text-light">Visit our Sunday Working Branches </a></li>
                    </ul>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card" style="background-color: #ffe600;">
                    <h6 class="text-center">About Bank</h6>
                    <div class="row">
                        <div class="col-md-6 col-sm-6 tile-desc">
                            <ul style="list-style: none;">
                                <li><i class="fa fa-arrow-circle-o-right"></i>&nbsp; &nbsp;<a class="text-dark" href="Profile.aspx">Profile</a></li>
                                <li><i class="fa fa-arrow-circle-o-right"></i>&nbsp; &nbsp;<a class="text-dark" href="Progress-at-glance.aspx">Progress at a Glance</a></li>
                                <li><i class="fa fa-arrow-circle-o-right"></i>&nbsp; &nbsp;<a class="text-dark" href="Board-of-Directors.aspx">Board of Directors</a></li>
                                <li><i class="fa fa-arrow-circle-o-right"></i>&nbsp; &nbsp;<a class="text-dark" href="Administration.aspx">Administration</a></li>
                                <li><i class="fa fa-arrow-circle-o-right"></i>&nbsp; &nbsp;<a class="text-dark" href="Financial-Results.aspx">Financial Results</a></li>
                                <li><i class="fa fa-arrow-circle-o-right"></i>&nbsp; &nbsp;<a class="text-dark" href="Shareholder.aspx">Shareholders' Benefit</a></li>
                                <li><i class="fa fa-arrow-circle-o-right"></i>&nbsp; &nbsp;<a class="text-dark" href="Awards.aspx">Awards</a></li>
                            </ul>
                        </div>
                        <div class="col-md-6 col-sm-6 hidden-xs">
                            <img src="Content/img/aboutbank.jpg" class="img-responsive" style="vertical-align: middle; width: 60%; margin-bottom: 0px;">
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <!-----footer------------->

    <div class="footer">
        <footer class="footer" role="contentinfo">
            <div id="back-top" style="display: none;"><a href="#top"><span><i class="fa fa-chevron-up"></i>Top</span><!-- Back to Top --></a> </div>
            <div class="top-footer">
                <div class="container" style="padding: 0 28px;">

                    <div id="menu-item-1434" class="pull-left" style="margin-top: 6px;">

                        <a href="Disclaimer.aspx" style="color: #FFF; font-size: 14px;">Disclaimer</a>
                    </div>

                    <div id="menu-item-1434" class="pull-right" style="color: #FFF; font-size: 14px; padding: 7px;"><span style="padding: 7px">© 2020 Abhyudaya Bank. All Rights Reserved</span></div>

                </div>
            </div>

            <!-- end #inner-footer -->


        </footer>
        <div class="Col-md-12" style="text-align: center; font-size: 14px; background: #eee; padding: 6px 40px;">
            ABHYUDAYA BANK HEAD-OFFICE : K.K.TOWER, Abhyudaya Bank Lane. off G. D. Ambekar Marg, Parel Village, Mumbai-400 012
            <br />
            Tel. : 022-24180961 / 24180962 / 24180963 / 24180964 
Fax-022-24109782
            <br />
            Contact us :: <a href="mailto:secretarial[at]abhyudayabank[dot]net">secretarial[at]abhyudayabank[dot]net</a>
        </div>
        <div class="Col-md-12">
            <div class="large-5" style="float: left; margin-left: 16px; margin-top: 4px; margin-bottom: 5px;">
                <img src="https://www.abhyudayabank.co.in/images/verisign.jpg" alt="Verisign" style="width: 58px;">&nbsp;&nbsp;&nbsp;<a href="https://ipv6-test.com/validate.php?url=www.abhyudayabank.co.in" target="_blank"><img
                    src="https://www.abhyudayabank.co.in/images/button-ipv6-small.png" alt="IPV6" style="width: 58px;"></a>
            </div>
            <div class="large-4" style="float: right; margin-right: 36px;">
                <a href="https://chicinfotech.com/" target="_blank">
                    <img src="https://www.abhyudayabank.co.in/images/chiclogo-signature.jpg" width="150" height="23" border="0" style="float: right; margin-right: 25px; margin-top: 9px;"></a>
            </div>
        </div>
    </div>


    <script src="https://cdn.jsdelivr.net/npm/jquery@3.5.1/dist/jquery.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-Fy6S3B9q64WdZWQUiU+q4/2Lc9npb8tCaSX9FK7E8HnRr0Jz8D6OP9dO5Vg3Q9ct" crossorigin="anonymous"></script>

</body>
</html>












