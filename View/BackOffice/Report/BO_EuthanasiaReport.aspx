<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/BO_MasterPage.Master" CodeBehind="BO_EuthanasiaReport.aspx.cs" Inherits="AnimalAdoptionSystem.View.BackOffice.Euthanasia.BO_EuthanasiaReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-3 ">Euthanasia Report</h2>
    <hr />

    <table style="display:block;margin:0 auto;width:100%;">
        <tr>
            <td style="padding:2em;">
                <canvas id="descDoughnutChart" style="padding-left:2em;width:100em;max-width:1180px;height:27em;"></canvas>
          
            </td>
        </tr>
        <tr>
            <td style="padding-top:10em;padding-left:2em;">
            
                <canvas id="statusBarChart" style="width:100em;max-width:1180px;height:30em;"></canvas>
                
            </td>
        </tr>
        <tr>
            <td style="padding-top:10em;padding-left:2em;padding-bottom:5em;">
            
                <canvas id="medPieChart" style="padding-left:5em;width:100em;max-width:1180px;height:30em;"></canvas>
                
            </td>
        </tr>
    </table>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>
    <script>
        //status Bar Chart

        new Chart("statusBarChart", {
            type: 'bar', //this denotes tha type of chart

            data: {// values on X-Axis
                labels: ['Ready', 'Pending', 'Completed', 'Cancelled',],
                datasets: [
                    {
                        label: "Status",
                        //data: ['467', '576', '572', '79', '92', '574', '573', '576'],
                        data: [<%=barData%>],
                        backgroundColor: '#A5C1DC'
                    }
                    //,
                    //{
                    //    label: "Profit",
                    //    data: ['542', '542', '536', '327', '17',
                    //        '0.00', '538', '541'],
                    //    backgroundColor: 'limegreen'
                    //}
                ]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false, 
                //aspectRatio: 2.5
                title: {
                    display: true,
                    text: 'Euthanasia Status',
                    fontSize: 18,
                    fontColor: "#111",
                    padding: 50, 
                }, 
                scales: {
                    x: {
                        title: {
                            display: true,
                            text: 'Status'
                        }
                    },
                    y: {
                        title: {
                            display: true,
                            text: 'Count'
                        },
                        min: 0,
                        max: 100,
                        ticks: {
                            // forces step size to be 50 units
                            stepSize: 1
                        }
                    }
                }
            }
        });


        // desc doughnut chart
        new Chart("descDoughnutChart", {
            type: 'doughnut', //this denotes tha type of chart

            data: {// values on X-Axis
                //labels: ['Ready', 'Pending', 'Completed', 'Cancelled',],
                labels: ["Terminal illness, e.g. cancer or rabies", "Behavioral problems e.g. aggression", "Old age and deterioration", "Lack of home or caretaker or resources for feeding", "Research and testing purpose", "Other"],
                datasets: [
                    {
                        label: "Reason",
                        data: [<%=doughnutData%>],
                        backgroundColor: [
                            "#9BBFE0",
                            "#E8A09A",
                            "#FBE29F",
                            "#C6D68F",
                            "#7982B9",
                            "#333333"
                        ],
                        borderColor: [
                            "#E9DAC6",
                            "#CBCBCB",
                            "#D88569",
                            "#E4CDA2",
                            "#89BC21"
                        ],
                        borderWidth: [1, 1, 1, 1, 1]
                    }
                ]
                
            },
            options: {
                responsive: true,
                title: {
                    display: true,
                    position: "top",
                    text: "Euthanasia Reason",
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

        //medicine pie chart

        var xValues = ["Pentobarbital Sodium", "Phenytoin Sodium", "Rhodamine B", "Bluish-red fluorescent dye", "Benzyl Alcohol", "IV Injection", "Seizure Medication", "Sedative", "Other"];
        var yValues = [<%=pieData%>];
        var barColors = [
            "#9BBFE0",
            "#E8A09A",
            "#FBE29F",
            "#C6D68F",
            "#7982B9",
            "#333333",
            "#E9F6FA",
            "#e8c3b9",
            "#868686"
        ];

        new Chart("medPieChart", {
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
                    text: "Most Used Drugs In Euthanasia",
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
        <asp:LinkButton ID="btnBack11" runat="server" Text="Back" CssClass="btn btn-primary ms-3"  OnClientClick="JavaScript:window.history.back(1); return false;" ></asp:LinkButton>
    </div>
    

</asp:Content>