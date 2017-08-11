<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AWS_SNS_API._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SNS Rest</title>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-2.0.3.min.js"></script>
    <!-- <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"/>-->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
    <style type="text/css">
        #TextArea1 {
            z-index: 1;
            left: 24px;
            top: 195px;
            position: absolute;
        }

        #sect {
            height: 232px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server" style="padding: 1%;">

        <h1>SNS Rest</h1>

        <div id="sect">
            <h3>Send a JSON-formatted SNS Alarm:</h3>
            <asp:TextBox ID="alarmText" runat="server" Style="z-index: 1; left: 25px; top: 127px; position: absolute; height: 57px; width: 257px;"></asp:TextBox>



            <asp:Button ID="Button1" runat="server" Style="z-index: 1; left: 30px; top: 208px; position: absolute" Text="Send Alarm" OnClick="Button1_Click1" />

        </div>
    </form>

</body>

</html>