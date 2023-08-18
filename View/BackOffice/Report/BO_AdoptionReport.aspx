<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BO_MasterPage.Master"  CodeBehind="BO_AdoptionReport.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Adoption.AdoptionReport" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3 ">Adoption Report</h2>
    <hr>

    <table style="display:block;margin:0 auto;width:100%;">
        
        <tr>
            <td style="padding:2em;">
            
                <canvas id="approvalStatusPieChart" style="width:100em;max-width:1180px;height:30em;"></canvas>
                
            </td>
        </tr>
        <tr>
            <td style="padding-top:10em;padding-left:2em;padding-bottom:5em;">
            
                <canvas id="rejectReasonBarChart" style="width:100em;max-width:1180px;height:30em;"></canvas>
                
            </td>
        </tr>
    </table>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>
    <script>
        //status Bar Chart
        new Chart("rejectReasonBarChart", {
            type: 'bar', 
            data: {
                labels: ['Underage', 'Crowded household', 'Long working hours', 'Small house size', 'Incomplete Application Information', 'Other',],
                datasets: [
                    {
                        label: "Reject Reason",
                        data: [<%=barData%>],
                        backgroundColor: '#A5C1DC'
                    }
                ]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false, 
                title: {
                    display: true,
                    text: 'Reason for Adoption Rejection',
                    fontSize: 18,
                    fontColor: "#111",
                    padding: 50, 
                }, 
                scales: {
                    y: {
                        ticks: {
                            stepSize: 1
                        }
                    }
                }
            }
        });
        
        //pie chart

        var xValues = ["New", "Approved", "Rejected", "Canceled"];
        var yValues = [<%=pieData%>];
        var barColors = [
            "#9BBFE0",
            "#E8A09A",
            "#FBE29F",
            "#333333",
        ];

        new Chart("approvalStatusPieChart", {
            type: "pie",
            data: {
                labels: xValues,
                datasets: [{
                    backgroundColor: barColors,
                    data: yValues
                }]
            },
            options: {
                title: {
                    display: true,
                    text: "Adoption Approval",
                    fontSize: 18,
                    fontColor: "#111",
                    padding: 50, 
                },
                legend: {
                    display: true,
                    position: "left",
                    labels: {
                        fontColor: "#333",
                        fontSize: 13
                    }
                }
            }
        });

        function onlyAdmin(url) {
            Swal.fire({
                position: 'center',
                icon: 'error',
                title: 'Oops',
                text: "You are unauthorized to view the page",
                showConfirmButton: true,
            }).then(function () {
                location.href = url;
            });
        }

    </script>

            
    <div style="float:right; margin-left:96em; margin-bottom:3em;">
        <asp:LinkButton ID="btnBack0" runat="server" Text="Back" CssClass="btn btn-primary ms-3"  OnClientClick="JavaScript:window.history.back(1); return false;" ></asp:LinkButton>
    </div>

</asp:Content>