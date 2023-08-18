<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="BO_Login.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.BO_Login" %>

<!DOCTYPE html>

<head runat="server">
    <title>Adopt Me Login</title>

    <meta name="viewport" content="width=device-width, initial-scale=1">
    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
        }
        form {
            border: 3px solid #f1f1f1;
        }
        input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
        }
        button:hover {
            opacity: 0.8;
        }
        .cnbtn {
            background-color: #ec3f3f;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 49%;
        }
        .lgnbtn {
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 50%;
        }
        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
        }
        img.avatar {
            width: 40%;
            border-radius: 50%;
        }
        .container {
            padding: 16px;
        }
        span.psw {
            float: right;
            padding-top: 16px;
        }

        @media screen and (max-width: 300px) {
            span.psw {
                display: block;
                float: none;
            }
            .cnbtn {
                width: 100%;
            }
        }
        .frmalg {
            margin: auto;
            width: 40%;
        }
    </style>

</head>
<body>
    <p style="height : 50px;"></p>
                <p></p><p></p>
                <p></p><p></p>
                <p></p>
    <form id="form1" runat="server" class="frmalg">

        <div class="container">
            <center>
                
                <h3>Adopt Me Staff Login </h3>
            </center>
            <label for="uname"><b>Email</b></label><p></p>
            <asp:TextBox runat="server" ID="txt_Username" placeholder="Enter Username" Width="543px"></asp:TextBox>
            <p></p>
            <label for="psw"><b>Password</b></label><p></p>
            <asp:TextBox runat="server" ID="txt_password" TextMode="Password" placeholder="Enter Password" Width="542px"></asp:TextBox>
            <asp:Button runat="server" ID="btn_Login" CssClass="lgnbtn" Text="Login" BackColor="Black" BorderColor="White" BorderWidth="1px" />
            <asp:Button runat="server" ID="btn_cancel" Text="Cancel" class="cnbtn" BackColor="Black" BorderColor="White" BorderWidth="1px" />
        </div>
    </form>
</body>
</html>