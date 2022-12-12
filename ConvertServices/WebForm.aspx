<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="ConvertServices.WebForm" %>

<!DOCTYPE html PUBLIC "–//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript" type="text/javascript">
        function Button1_onclick() {
            let val = document.getElementById("val").value;

            val = parseFloat(val);

            var service = new ConvertServices.WeightConverter();
            service.UahToDollars(val, onSuccess, null, null);
        }
        function onSuccess(result) {
            alert(`It's  ${result} dollar/s`);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Services>
                    <asp:ServiceReference Path="WeightConverter.svc" />
                </Services>
            </asp:ScriptManager>
            <input id="val" type="number" name="value"  step="0.01"/>
            <input id="Button1" type="submit" value="Convert" onclick="return Button1_onclick()" />
        </div>
    </form>
</body>
</html>
